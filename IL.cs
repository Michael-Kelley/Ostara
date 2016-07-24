using System.Reflection.Emit;

namespace Ostara {
	unsafe static class IL {
		public delegate void CpblkFunction(void* dest, void* src, uint length);
		public static readonly CpblkFunction Cpblk;

		static IL() {
			var dynamicMethod = new DynamicMethod(
				"Cpblk",
				typeof(void),
				new[] {
					typeof(void*),
					typeof(void*),
					typeof(uint)
				},
				typeof(IL)
			);

			var gen = dynamicMethod.GetILGenerator();

			gen.Emit(OpCodes.Ldarg_0);
			gen.Emit(OpCodes.Ldarg_1);
			gen.Emit(OpCodes.Ldarg_2);

			gen.Emit(OpCodes.Cpblk);
			gen.Emit(OpCodes.Ret);

			Cpblk = (CpblkFunction)dynamicMethod.CreateDelegate(typeof(CpblkFunction));
		}
	}
}