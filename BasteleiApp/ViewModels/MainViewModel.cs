using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using BasteleiApp.Models;
using System.ComponentModel.Composition;

namespace BasteleiApp.ViewModels {
  [Export(typeof(MainViewModel))]
  class MainViewModel : Screen {

    #region Fields
    
    private BindableCollection<object> _tabs;
    private object _selectedItem;
    private string _windowTitle;
    private readonly IWindowManager _windowManager;

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

    public object SelectedItem
    {
      get
      {
        return _selectedItem;
      }

      set
      {
        _selectedItem = value;
        NotifyOfPropertyChange(() => SelectedItem);
      }
    }

    #endregion //Properties

    #region Constructors

    [ImportingConstructor]
    public MainViewModel(IWindowManager windowManager) {
      WindowTitle = "bastelei";
      Tabs = new BindableCollection<object>();
      Tabs.Add(new DataPresentationViewModel());
      Tabs.Add(new ControlPanelViewModel());
      _windowManager = windowManager;
    }

    #endregion //Constructors

    #region Methods

    public void TabSelectionChanged() {
      if(SelectedItem.GetType() == typeof(ControlPanelViewModel)) {
        _windowManager.ShowWindow(new LoginViewModel());
      }
    }

    #endregion //Methods

  }
}
