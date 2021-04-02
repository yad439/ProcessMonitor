using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject.Modules;

namespace ProcessGui {
	internal class DiModule :NinjectModule {
		public override void Load() {
			Bind<ServiceManager>().ToSelf();
			Bind<MainWindow>().ToSelf();
		}
	}
}
