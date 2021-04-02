using System;
using System.Diagnostics;
using System.Threading;

namespace ProcessService {
	internal class Program {
		static void Main() {
			var connection = new SerializationManager(Console.Out);
			while (true) {
				var processes = Process.GetProcesses();
				connection.SendProcesses(processes);
				Thread.Sleep(1000);
			}
		}
	}
}