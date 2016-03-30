using System;
using System.Reflection;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using BasteleiApp.ViewModels;
using System.IO;

namespace BasteleiApp {
  class AppBootstrapper : BootstrapperBase {
    public AppBootstrapper() {
      Initialize();
    }

    protected override void OnStartup(object sender, StartupEventArgs e) {
      DisplayRootViewFor<MainViewModel>();
    }
    
  }
}
