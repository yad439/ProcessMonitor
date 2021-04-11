using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ProcessService {
	internal sealed class SerializationManager {
		public void SendProcesses(TextWriter writer, IEnumerable<ProcessDto> processes) {
			var json = JsonSerializer.Serialize(processes);
			writer.WriteLine(json);
			writer.Flush();
		}
	}
}