
namespace Ostara {
	static class Math {
		public static uint NextPow2(this uint v) {
			v--;
			v |= v >> 1;
			v |= v >> 2;
			v |= v >> 4;
			v |= v >> 8;
			v |= v >> 16;
			v++;

			return v;
		}
	}
}