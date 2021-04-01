using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace ProcessGui {
	internal class ServiceManager {
		public delegate void UpdateProcessesHandler(IEnumerable<ProcessDto> processes);
		public event UpdateProcessesHandler UpdateProcesses;

		private Process _process;

		public void Start() {
			var startInfo = new ProcessStartInfo {
				FileName = "ProcessService.exe",
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true,
			};
			_process = Process.Start(startInfo);
			_process.OutputDataReceived += OnProcessDataRecieved;
			_process.BeginOutputReadLine();
		}

		private void OnProcessDataRecieved(object sender, DataReceivedEventArgs e) {
			if (e.Data == null) return;
			var processes = JsonSerializer.Deserialize<ProcessDto[]>(e.Data);
			UpdateProcesses(processes);
		}
	}
}
