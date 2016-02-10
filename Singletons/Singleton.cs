using System;

namespace Ostara {
	// There can be only one.
	class Singleton<T> where T: class, new() {
		static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

		public static T I => _instance.Value;
	}
}