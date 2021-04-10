using System;
using System.Diagnostics;
using System.Threading;

namespace ProcessService {
	internal static class Program {
		private static void Main() {
			var connection = new ConnectionManager(new SerializationManager());
			var settings = connection.Settings;
			settings.Timeout = 1000;
			while (true) {
				var processes = Process.GetProcesses();
				connection.SendProcesses(processes);
				Thread.Sleep(settings.Timeout);
			}
		}
	}
}