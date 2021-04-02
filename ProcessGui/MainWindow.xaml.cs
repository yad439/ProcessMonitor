using System;
using System.Collections.Generic;
using System.Windows;

namespace ProcessGui {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	internal sealed partial class MainWindow : Window {
		private readonly ServiceManager _service;

		public MainWindow() {
			InitializeComponent();
			_service = new ServiceManager();
			_service.UpdateProcesses += UpdateProcessList;
			_service.Start();
		}

		private void UpdateProcessList(IEnumerable<ProcessDto> processes) {
			ProcessesListView.Dispatcher.Invoke(() => {
				var items = ProcessesListView.Items;
				items.Clear();
				foreach (var process in processes) {
					items.Add(process);
				}
			});
		}

		protected override void OnClosed(EventArgs e) {
			base.OnClosed(e);
			_service.Stop();
		}
	}
}