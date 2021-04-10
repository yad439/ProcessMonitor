using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProcessGui {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	internal sealed partial class MainWindow : Window {
		private readonly ProcessViewModel _viewModel;

		public MainWindow(ProcessViewModel viewModel) {
			InitializeComponent();

			_viewModel = viewModel;
			DataContext = _viewModel;

			var view = CollectionViewSource.GetDefaultView(_viewModel.Processes);
			view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
			view.Refresh();

			_viewModel.StartUpdate();
		}

		protected override void OnClosed(EventArgs e) {
			base.OnClosed(e);
			_viewModel.StopUpdate();
		}

		private void ChangeUpdateInterval(object sender, SelectionChangedEventArgs e) {
			var box = (ComboBox)sender;
			var selection = (TimeoutItem) box.SelectedItem;
			_viewModel?.SetUpdateInterval(selection.Value);
		}
	}
}