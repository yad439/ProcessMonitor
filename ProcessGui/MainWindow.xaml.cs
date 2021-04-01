using System.Linq;
using System.Windows;


namespace ProcessGui {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			var service = new ServiceManager();
			service.Start();
			service.UpdateProcesses += (procs) => processesListView.Dispatcher.Invoke(() => processesListView.Items.Add(procs.First()));
		}
	}
}
