
namespace Ostara {
	public unsafe class Cryption {
		readonly uint[] masks = { 0x00000000, 0x000000FF, 0x0000FFFF, 0x00FFFFFF };
		readonly byte[] keychain;

		uint headerXor, mul;
		int step;

		bool first = true;
		bool isRemote;

		readonly int incHdrSize, outHdrSize;

		public Cryption(bool isRemote) {
			this.isRemote = isRemote;
			keychain = new byte[0x20000];
			GenerateKeychain(0x8F54C37B, 0, 0x4000);
			headerXor = 0x12345678; // RANDOM LOL

			if (isRemote) {
				incHdrSize = 4;
				outHdrSize = 8;
			}
			else {
				incHdrSize = 8;
				outHdrSize = 4;
			}

			step = 0;
			mul = 1;
		}

		public void Do(byte[] packet, int index, int size, bool encrypt) {
			fixed (byte* ppacket = &packet[index], pkeychain = keychain)
			{
				var hdrSize = (encrypt) ? outHdrSize : incHdrSize;

				if (encrypt)
					*((uint*)ppacket) ^= (!isRemote) ? 0x7AB38CF1 : headerXor;

				var token = *((uint*)ppacket);
				token &= 0x3FFF;
				token *= ((isRemote && encrypt) || (!isRemote && !encrypt)) ? mul : 1;
				token *= 4;
				token = *((uint*)&pkeychain[token]);

				if (!encrypt) {
					if (first) {
						*((uint*)ppacket) = 0x000EB7E2;
						first = false;
					}
					else
						*((uint*)ppacket) ^= (isRemote) ? 0x7AB38CF1 : headerXor;
				}

				int i;
				int t = (size - hdrSize) / 4;  // Process in blocks of 32 bits (4 bytes)

				for (i = hdrSize; t > 0; i += 4, t--) {
					var t1 = *((uint*)&ppacket[i]);
					*((uint*)&ppacket[i]) = t1 ^ token;

					if (encrypt)
						t1 ^= token;

					t1 &= 0x3FFF;
					t1 *= ((!isRemote && encrypt) || (isRemote && !encrypt)) ? mul : 1;
					t1 *= 4;
					token = *((uint*)&pkeychain[t1]);
				}

				var t2 = *((uint*)&ppacket[i]);
				*((uint*)&ppacket[i]) = t2 ^ (token & masks[(size - hdrSize) & 3]);

				if (isRemote && encrypt) {
					t2 ^= (token & masks[(size - hdrSize) & 3]);

					token &= 0x3FFF;
					token *= mul;
					token *= 4;
					token = t2 ^ *((uint*)&pkeychain[token]);

					*((uint*)&ppacket[4]) = token;
				}

				if ((isRemote && encrypt) ||
					(!isRemote && !encrypt)) {
					step++;
					step &= 0x3FFF;
					headerXor = *((uint*)&pkeychain[step * mul * 4]);
				}
			}
		}

		public void GenerateKeychain(uint key, int position, int size) {
			for (var i = position; i < position + size; i++) {
				var a = key * 0x2F6B6F5;
				a += 0x14698B7;

				var b = a * 0x2F6B6F5;
				b += 0x14698B7;

				key = b;

				a >>= 0x10;
				a *= 0x27F41C3;
				a += 0x0B327BD;

				b >>= 0x10;
				b *= 0x27F41C3;
				b += 0x0B327BD;

				a >>= 0x10;
				b &= 0xFFFF0000;
				a |= b;

				fixed (byte* pkeychain = keychain)
					*((uint*)&pkeychain[i * 4]) = a;
			}
		}

		public void ChangeKeychain(uint key, int step) {
			mul = 2;
			step--;

			if (step < 0)
				step += 0x4000;

			GenerateKeychain(key, 0x4000, 0x4000);

			fixed (byte* pkeychain = keychain)
				headerXor = *((uint*)&pkeychain[step * mul * 4]);

			this.step = step;
		}

		public int GetPacketSize(byte[] packet, int index) {
			if (first)
				return 0x0E;

			uint header;

			fixed (byte* ppacket = packet)
				header = *((uint*)&ppacket[index]);

			header ^= headerXor;
			header >>= 16;

			return (int)header;
		}
	}
}