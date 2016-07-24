using System;

using static Ostara.IL;

namespace Ostara {
	public unsafe class PacketReader : IDisposable {
		byte[] _data;
		int _index;

		public byte this[int index] => _data[index];

		public byte[] this[int index, int count] {
			get {
				var r = new byte[count];

				fixed (byte* pr = r, pdata = _data)
				{
					var pd = pdata;
					pd += index;

					Cpblk(pr, pd, (uint)count);
				}

				return r;
			}
		}

		public ushort Opcode { get; private set; }
		public int Size { get; private set; }

		public void New(byte[] b, int index, int size, bool isOutgoing) {
			_data = b;
			_index = index;
			Size = size;
			var isExt = _data[0] == 0xF3;
			var offset = isOutgoing ? 8 : isExt ? 6 : 4;
			Opcode = _data[index + offset];
			Opcode += (ushort)(_data[index + offset + 1] << 8);

			this._index += offset + 2;
		}

		public void Skip(int bytes) { _index += bytes; }

		public byte[] ReadBytes(int count) {
			var result = new byte[count];

			fixed (byte* pr = result, pdata = _data)
			{
				var pd = pdata;
				pd += _index;

				Cpblk(pr, pd, (uint)count);
			}

			_index += count;

			return result;
		}

		public long ReadLong() {
			long result;

			fixed (byte* pdata = _data)
			{
				var pd = pdata;
				pd += _index;

				result = *((long*)pd);
				_index += 8;
			}

			return result;
		}

		public ulong ReadULong() {
			ulong result;

			fixed (byte* pdata = _data)
			{
				var pd = pdata;
				pd += _index;

				result = *((ulong*)pd);
				_index += 8;
			}

			return result;
		}

		public int ReadInt() {
			int result;

			fixed (byte* pdata = _data)
			{
				var pd = pdata;
				pd += _index;

				result = *((int*)pd);
				_index += 4;
			}

			return result;
		}

		public uint ReadUInt() {
			uint result;

			fixed (byte* pdata = _data)
			{
				var pd = pdata;
				pd += _index;

				result = *((uint*)pd);
				_index += 4;
			}

			return result;
		}

		public short ReadShort() {
			short result;

			fixed (byte* pdata = _data)
			{
				var pd = pdata;
				pd += _index;

				result = *((short*)pd);
				_index += 2;
			}

			return result;
		}

		public ushort ReadUShort() {
			ushort result;

			fixed (byte* pdata = _data)
			{
				var pd = pdata;
				pd += _index;

				result = *((ushort*)pd);
				_index += 2;
			}

			return result;
		}

		public byte ReadByte() {
			var result = _data[_index];
			_index += 1;

			return result;
		}

		public float ReadFloat() {
			float result;

			fixed (byte* pdata = _data)
			{
				var pd = pdata;
				pd += _index;

				result = *((float*)pd);
				_index += 4;
			}

			return result;
		}

		public double ReadDouble() {
			double result;

			fixed (byte* pdata = _data)
			{
				var pd = pdata;
				pd += _index;

				result = *((double*)pd);
				_index += 8;
			}

			return result;
		}

		public string ReadString(int length) {
			var result = System.Text.Encoding.ASCII.GetString(_data, _index, length);

			_index += length;

			return result;
		}

		public bool ReadBool() {
			var result = ReadByte();

			return (result == 1);
		}

		public void Dispose() {
			_data = null;
		}
	}
}