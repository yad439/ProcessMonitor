﻿using System.Collections.Generic;
using System.Windows;

namespace ProcessGui {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	internal sealed partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			var service = new ServiceManager();
			service.Start();
			service.UpdateProcesses += UpdateProcessList;
		}

		private void UpdateProcessList(IEnumerable<ProcessDto> processes) {
			processesListView.Dispatcher.Invoke(() => {
				var items = processesListView.Items;
				items.Clear();
				foreach (var process in processes) {
					items.Add(process);
				}
			});
		}
	}
}