using System.Windows;

using Ninject;

namespace ProcessGui {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App {
		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);
			var kernel = new KernelConfiguration(new DiModule()).BuildReadonlyKernel();
			var window = kernel.Get<MainWindow>();
			MainWindow = window;
			window.Show();
		}
	}
}
