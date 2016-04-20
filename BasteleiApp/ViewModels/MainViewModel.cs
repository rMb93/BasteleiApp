using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using BasteleiApp.Models;

namespace BasteleiApp.ViewModels {
  class MainViewModel : Screen {

    #region Fields
    
    private BindableCollection<object> _tabs;
    private string _windowTitle;

    #endregion //Fields

    #region Properties

    public BindableCollection<object> Tabs
    {
      get
      {
        return _tabs;
      }

      set
      {
        _tabs = value;
        NotifyOfPropertyChange(() => Tabs);
      }
    }

    public string WindowTitle {
      get {
        return _windowTitle;
      }

      set {
        _windowTitle = value;
        NotifyOfPropertyChange(() => WindowTitle);
      }
    }

    #endregion //Properties

    #region Constructors

    public MainViewModel() {
      WindowTitle = "bastelei";
      Tabs = new BindableCollection<object>();
      Tabs.Add(new DataPresentationViewModel());
      Tabs.Add(new ControlPanelViewModel());
    }

    #endregion //Constructors

    #region Methods

    #endregion //Methods

  }
}
