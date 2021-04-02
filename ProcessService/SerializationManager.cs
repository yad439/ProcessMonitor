using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ProcessService {
	internal class SerializationManager {
		private readonly TextWriter _writer;

		public SerializationManager(TextWriter writer) { _writer = writer; }

		public void SendProcesses(IEnumerable<Process> processes) {
			var forSerialization = processes.Select(proc => new ProcessDto {Name = proc.ProcessName}).ToList();
			var json = JsonSerializer.Serialize(forSerialization);
			_writer.WriteLine(json);
			_writer.Flush();
		}

		private struct ProcessDto {
			public string Name { get; set; }
		}
	}
}