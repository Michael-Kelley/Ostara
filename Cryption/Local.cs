
namespace Ostara {
	public unsafe class LocalCryption {
		readonly uint[] masks = { 0x00000000, 0x000000FF, 0x0000FFFF, 0x00FFFFFF };
		readonly byte[] keychain;

		uint headerXor, mul;
		int step;
		bool first = true;

		public LocalCryption() {
			keychain = new byte[0x20000];
			GenerateKeychain(0x8F54C37B, 0, 0x4000);

			step = 0;
			mul = 1;
		}

		public void Encrypt(byte[] packet, int index, int size) {
			fixed (byte* ppacket = &packet[index], pkeychain = keychain)
			{
				*((uint*)ppacket) ^= 0x7AB38CF1;
				var token = *((uint*)ppacket);
				token &= 0x3FFF;
				token *= 4;
				token = *((uint*)&pkeychain[token]);

				int i, t = (size - 4) / 4;  // Process in blocks of 32 bits (4 bytes)

				for (i = 4; t > 0; i += 4, t--) {
					var t1 = *((uint*)&ppacket[i]);
					t1 ^= token;
					*((uint*)&ppacket[i]) = t1;

					t1 &= 0x3FFF;
					t1 *= 4;
					token = *((uint*)&pkeychain[t1]);
				}

				token &= masks[(size - 4) & 3];
				*((uint*)&ppacket[i]) ^= token;
			}
		}

		public void Decrypt(byte[] packet, int index, int size) {
			var header = (uint)GetPacketSize(packet, index);
			header <<= 16;
			header += 0xB7E2;

			if (first)
				first = false;

			fixed (byte* ppacket = &packet[index], pkeychain = keychain)
			{
				var token = *((uint*)ppacket);
				token &= 0x3FFF;
				token *= mul;
				token *= 4;
				token = *((uint*)&pkeychain[token]);
				*((uint*)ppacket) = header;

				int i, t = (size - 8) / 4;  // Process in blocks of 32 bits (4 bytes)

				for (i = 8; t > 0; i += 4, t--) {
					var t1 = *((uint*)&ppacket[i]);
					token ^= t1;
					*((uint*)&ppacket[i]) = token;

					t1 &= 0x3FFF;
					t1 *= mul;
					t1 *= 4;
					token = *((uint*)&pkeychain[t1]);
				}

				token &= masks[(size - 8) & 3];
				*((uint*)&ppacket[i]) ^= token;

				*((uint*)&ppacket[4]) = 0;

				step++;
				step &= 0x3FFF;
				headerXor = *((uint*)&pkeychain[step * mul * 4]);
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

		public uint GetPacketSize(byte[] packet, int index) {
			if (first)
				return 0x0E;

			uint header;

			fixed (byte* ppacket = packet)
				header = *((uint*)&ppacket[index]);

			header ^= headerXor;
			header >>= 16;

			return header;
		}
	}
}