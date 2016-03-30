using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace BasteleiApp.ViewModels {
  class MainViewModel : PropertyChangedBase {
    private const string WindowTitleDefault = "bastelei";

    private string _windowTitle = WindowTitleDefault;

    public string WindowTitle
    {
      get { return _windowTitle; }
      set
      {
        _windowTitle = value;
        NotifyOfPropertyChange(() => WindowTitle);
      }
    }

    public bool CanLoadLocBtn {
        get { return true; }
    }

    public void LoadLocBtn() {
      WindowTitle = "blub";
    }
  }
}
