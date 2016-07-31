using System;

namespace Ostara.Cryption {
	public unsafe class Server {
		public byte[] Keychain;
		public uint Step, Mul;
		const uint HEADER_XOR = 0x7AB38CF1;

		public Server() {
			Keychain = new byte[0x20000];
			GenerateKeychain(0x8F54C37B, 0, 0x4000);

			Step = 0;
			Mul = 1;
		}

		public void Decrypt(byte[] packet) {
			fixed (byte* pp = packet, pk = Keychain) {
				uint size = (uint)GetPacketSize(packet);
				uint t =  (uint)((*(int*)&pp[0] & 0x3FFF) * 4);
				uint Key = *(uint*)&pk[t];
				*(uint*)&pp[0] ^= HEADER_XOR;

				uint i, r, t1;
				size -= r = (size - 4) & 3;

				for (i = 4; i < size; i += 4) {
					t1 = *(uint*)&pp[i];
					Key ^= t1;
					*(uint*)&pp[i] = Key;
					t1 &= 0x3FFF;
					Key = *(uint*)&pk[t1 * 4];
				}

				t1 = 0xFFFFFFFF >> 8 * (4 - (int)r);
				t1 &= Key;
				*(uint*)&pp[i] ^= t1;
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
		}

		public int GetPacketSize(byte[] packet) {
			int size;

			fixed (byte* pp = packet) {
				var header = *(uint*)&pp[0];
				header ^= HEADER_XOR;

				if (*(ushort*)&header == 0xC8F3) {
					var xheader = *(UInt64*)&pp[0];

					uint t = *(uint*)&pp[0];
					t &= 0x3FFF;
					t *= 4;
					uint key;

					fixed (byte* pk = Keychain)
						key = *(uint*)&pk[t];

					var pxh = (uint*)&xheader;
					pxh[0] ^= HEADER_XOR;
					pxh[1] ^= key;

					xheader >>= 16;
					xheader &= 0xFFFFFFFF;

					size = (int)xheader;
				} else {
					header >>= 16;
					size = (int)header;
				}
			}

			return size;
		}
	}
}