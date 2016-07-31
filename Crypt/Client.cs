using System;

namespace Ostara.Cryption {
	public unsafe class Client {
		public byte[] Keychain;
		public uint Step, Mul, HeaderXor;

		bool first = true;

		public Client() {
			Keychain = new byte[0x20000];
			GenerateKeychain(0x8F54C37B, 0, 0x4000);

			Step = 0;
			Mul = 1;
		}

		public void Decrypt(byte[] packet) {
			fixed (byte* pp = packet, pk = Keychain) {
				uint size = (uint)GetPacketSize(packet);
				uint header = (first) ?
					0x000eb7e2 :
					*((uint*)&pp[0]) ^ HeaderXor;

				if (first)
					first = false;

				uint token = *((uint*)&pp[0]);
				*((uint*)&pp[0]) = header;
				token &= 0x3FFF;
				token *= Mul * 4;
				token = *((uint*)&pk[token]);

				uint i, r, t;
				size -= r = (size - 8) & 3;

				for (i = 8; i < size; i += 4) {
					t = *((uint*)&pp[i]);
					token ^= t;
					*((uint*)&pp[i]) = token;

					t &= 0x3FFF;
					token = *((uint*)&pk[t * Mul * 4]);
				}

				t = 0xFFFFFFFF >> 8 * (4 - (int)r);
				token &= t;
				*((uint*)&pp[i]) ^= token;

				*((uint*)&pp[4]) = 0;

				Step++;
				Step &= 0x3FFF;
				HeaderXor = *((uint*)&pk[Step * Mul * 4]);
			}
		}

		public void GenerateKeychain(uint key, int position, int size) {
			uint ret2;
			uint ret3;
			uint ret4;

			for (int i = position; i < position + size; i++) {
				ret4 = key * 0x2F6B6F5;
				ret4 += 0x14698B7;
				ret2 = ret4;
				ret4 = ret4 >> 0x10;
				ret4 = ret4 * 0x27F41C3;
				ret4 += 0x0B327BD;
				ret4 = ret4 >> 0x10;

				ret3 = ret2 * 0x2F6B6F5;
				ret3 += 0x14698B7;
				key = ret3;
				ret3 = ret3 >> 0x10;
				ret3 = ret3 * 0x27F41C3;
				ret3 += 0x0B327BD;
				ret3 = ret3 >> 0x10;
				ret3 = ret3 << 0x10;

				ret4 = ret4 | ret3;

				fixed (byte* pk = Keychain)
					*(uint*)&pk[i * 4] = ret4;
			}
		}

		public void ChangeKey(uint key, uint step) {
			Mul = 2;
			Step = step - 1U;

			if ((int)Step < 0)
				Step = (uint)((int)Step + 0x4000);

			GenerateKeychain(key, 0x4000, 0x4000);

			fixed (byte* pk = Keychain)
				HeaderXor = *(uint*)&pk[Step * Mul * 4];
		}

		public int GetPacketSize(byte[] packet) {
			if (first)
				return 0x0E;

			uint header;
			fixed (byte* pp = packet)
				header = *(uint*)&pp[0];

			header ^= HeaderXor;
			header >>= 16;

			return (int)header;
		}

		public bool IsValid(byte[] packet) {
			if (first)
				return true;

			var header = packet[0];

			header ^= (byte)(HeaderXor & 0xFF);

			return (header == 0xE2);
		}
	}
}