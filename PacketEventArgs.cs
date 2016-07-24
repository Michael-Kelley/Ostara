using System;

namespace Ostara {
	class PacketEventArgs : EventArgs {
		public PacketInfo Packet;
		public Action OnSend;
	}
}