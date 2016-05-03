using System;
using System.Reflection;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using BasteleiApp.ViewModels;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Windows.Controls;

namespace BasteleiApp {
  class AppBootstrapper : BootstrapperBase {

    private CompositionContainer container;

    public AppBootstrapper() {
      Initialize();
      ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
    }

    protected override void OnStartup(object sender, StartupEventArgs e) {
      DisplayRootViewFor<MainViewModel>();
    }

    protected override void Configure() {
      container = new CompositionContainer(new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()));

      CompositionBatch batch = new CompositionBatch();

      batch.AddExportedValue<IWindowManager>(new WindowManager());
      batch.AddExportedValue<IEventAggregator>(new EventAggregator());
      batch.AddExportedValue(container);

      container.Compose(batch);
    }

    protected override object GetInstance(Type serviceType, string key) {
      string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
      var exports = container.GetExportedValues<object>(contract);

      foreach (var export in exports) {
        return export;
      }

      throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
    }
  }
}
