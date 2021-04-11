using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ProcessService {
	internal static class Program {
		private static void Main() {
			var connection = new ConnectionManager(new SerializationManager());
			var settings = connection.Settings;
			settings.Timeout = 1000;
			while (true) {
				var processes = Process.GetProcesses();
				var dtos = processes.Select(process => {
					var dto = new ProcessDto {Name = process.ProcessName, MemoryUsage = process.PrivateMemorySize64};
					return dto;
				});
				connection.SendProcesses(dtos);
				foreach (var process in processes) {
					process.Dispose();
				}

				Thread.Sleep(settings.Timeout);
			}
		}
	}
}