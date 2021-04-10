using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessService {
	internal sealed class ConnectionManager {
		private readonly SerializationManager _serializationManager;
		public Settings Settings { get; } = new();

		public ConnectionManager(SerializationManager serializationManager) {
			_serializationManager = serializationManager;
			new Thread(ReadSettings).Start();
		}

		public void SendProcesses(IEnumerable<Process> processes) => _serializationManager.SendProcesses(Console.Out, processes);

		private void ReadSettings() {
			while (true) {
				var input = Console.ReadLine();
				if (input == null) return;
				Settings.Timeout = int.Parse(input);
			}
		}
	}
}