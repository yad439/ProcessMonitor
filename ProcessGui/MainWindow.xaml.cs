using System;
using System.Windows;
using System.Windows.Controls;

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