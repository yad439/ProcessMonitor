using System.Windows;

using Ninject;

namespace ProcessGui {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App {
		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);
			const string servicePath = "ProcessService.exe";
			var kernel = new KernelConfiguration(new DiModule(servicePath)).BuildReadonlyKernel();
			var window = kernel.Get<MainWindow>();
			window.Show();
			MainWindow = window;
		}
	}
}
