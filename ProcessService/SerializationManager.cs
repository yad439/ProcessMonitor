using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ProcessService {
	internal sealed class SerializationManager {
		public void SendProcesses(TextWriter writer, IEnumerable<Process> processes) {
			var forSerialization = processes.Select(proc => new ProcessDto {Name = proc.ProcessName}).ToArray();
			var json = JsonSerializer.Serialize(forSerialization);
			writer.WriteLine(json);
			writer.Flush();
		}

		private struct ProcessDto {
			public string Name { get; set; }
		}
	}
}