using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace ProcessGui {
	internal sealed class ServiceManager : IDisposable {
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
			_process.OutputDataReceived += OnProcessDataReceived;
			_process.BeginOutputReadLine();
		}

		public void Stop() {
			if (_process == null) return;

			_process.Kill();
			_process.WaitForExit();
			_process.Dispose();
			_process = null;
		}

		private void OnProcessDataReceived(object sender, DataReceivedEventArgs e) {
			if (e.Data == null) return;

			var processes = JsonSerializer.Deserialize<ProcessDto[]>(e.Data);
			UpdateProcesses(processes);
		}

		public void Dispose() => Stop();
	}
}