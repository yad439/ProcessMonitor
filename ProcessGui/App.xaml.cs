using System.Windows;
using Ninject;

namespace ProcessGui {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App {
		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);
			var servicePath = e.Args.Length > 0 ? e.Args[1] : "ProcessService";
			var kernel = new KernelConfiguration(new DiModule(servicePath)).BuildReadonlyKernel();
			var window = kernel.Get<MainWindow>();
			window.Show();
			window.Loaded += (_, _) => MainWindow = window;
		}
	}
}