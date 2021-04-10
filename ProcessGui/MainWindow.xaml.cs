using System;
using System.Windows;

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
	}
}