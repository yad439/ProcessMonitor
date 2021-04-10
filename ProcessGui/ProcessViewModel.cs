using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ProcessGui {
	internal sealed class ProcessViewModel {
		public ObservableCollection<ProcessDto> Processes { get; } = new();

		private readonly ServiceManager _serviceManager;

		public ProcessViewModel(ServiceManager serviceManager) {
			_serviceManager = serviceManager;
			_serviceManager.UpdateProcesses += UpdateProcesses;
		}

		public void StartUpdate() => _serviceManager.Start();

		public void StopUpdate() => _serviceManager.Stop();

		public void SetUpdateInterval(int milliseconds) => _serviceManager.SetUpdateInterval(milliseconds);

		private void UpdateProcesses(IEnumerable<ProcessDto> processes) {
			Application.Current.Dispatcher.Invoke(() => {
				Processes.Clear();
				foreach (var process in processes) {
					Processes.Add(process);
				}
			});
		}
	}
}