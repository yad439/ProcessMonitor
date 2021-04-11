using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace ProcessGui {
	internal sealed class ProcessViewModel {
		public ObservableCollection<ProcessDto> Processes { get; } = new();

		private readonly ICollectionView _collectionView;
		private readonly ServiceManager _serviceManager;

		public ProcessViewModel(ServiceManager serviceManager) {
			_serviceManager = serviceManager;
			_serviceManager.UpdateProcesses += UpdateProcesses;

			_collectionView = CollectionViewSource.GetDefaultView(Processes);
			_collectionView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
			_collectionView.Refresh();
		}

		public void StartUpdate() => _serviceManager.Start();

		public void StopUpdate() => _serviceManager.Stop();

		public void SetUpdateInterval(int milliseconds) => _serviceManager.SetUpdateInterval(milliseconds);

		public void UpdateSorting(string column) {
			var currentSorting = _collectionView.SortDescriptions.First();
			var order = column == currentSorting.PropertyName && currentSorting.Direction == ListSortDirection.Ascending
							? ListSortDirection.Descending
							: ListSortDirection.Ascending;
			_collectionView.SortDescriptions.Clear();
			_collectionView.SortDescriptions.Add(new SortDescription(column, order));
			_collectionView.Refresh();
		}

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