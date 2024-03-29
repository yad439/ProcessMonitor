﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;

namespace ProcessGui {
	internal sealed class ServiceManager : IDisposable {
		public delegate void UpdateProcessesHandler(IEnumerable<ProcessDto> processes);

		public event UpdateProcessesHandler UpdateProcesses;

		private readonly string _executablePath;
		private Process _process;

		public ServiceManager(string executablePath) { _executablePath = executablePath; }

		public void Start() {
			var startInfo = new ProcessStartInfo {
													 FileName = _executablePath,
													 RedirectStandardOutput = true,
													 RedirectStandardInput = true,
													 UseShellExecute = false,
													 CreateNoWindow = true,
												 };
			try {
				_process = Process.Start(startInfo);
			} catch (Win32Exception e) {
				throw new ServiceCanNotStartException("Win32 exception", e);
			}

			if (_process == null) throw new ServiceCanNotStartException("Unexpected exception");

			_process.OutputDataReceived += OnProcessDataReceived;
			_process.BeginOutputReadLine();
		}

		public void SetUpdateInterval(int milliseconds) {
			var stream = _process.StandardInput;
			stream.WriteLine(milliseconds);
			stream.Flush();
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
			UpdateProcesses?.Invoke(processes);
		}

		public void Dispose() => Stop();
	}
}