using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProcessGui {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	internal sealed partial class MainWindow {
		private readonly ProcessViewModel _viewModel;

		public MainWindow(ProcessViewModel viewModel) {
			InitializeComponent();

			_viewModel = viewModel;
			DataContext = _viewModel;

			_viewModel.StartUpdate();
		}

		protected override void OnClosed(EventArgs e) {
			base.OnClosed(e);
			_viewModel.StopUpdate();
		}

		private void ChangeUpdateInterval(object sender, SelectionChangedEventArgs e) {
			var box = (ComboBox) sender;
			var selection = (TimeoutItem) box.SelectedItem;
			_viewModel?.SetUpdateInterval(selection.Value);
		}

		private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e) {
			var header = (GridViewColumnHeader) e.OriginalSource;
			Debug.Assert(header.Column.DisplayMemberBinding != null);
			var column = ((Binding) header.Column.DisplayMemberBinding).Path.Path;
			_viewModel.UpdateSorting(column);
		}
	}
}