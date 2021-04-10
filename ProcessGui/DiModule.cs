using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject.Modules;

namespace ProcessGui {
	internal class DiModule :NinjectModule {
		private readonly string _servicePath;

		public DiModule(string servicePath) { _servicePath = servicePath; }

		public override void Load() {
			Bind<ServiceManager>().ToSelf().WithConstructorArgument(_servicePath);
			Bind<ProcessViewModel>().ToSelf();
			Bind<MainWindow>().ToSelf();
		}
	}
}
