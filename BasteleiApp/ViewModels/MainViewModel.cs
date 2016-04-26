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
  class MainViewModel : Conductor<IMainScreenTabItem>.Collection.OneActive {

    #region Fields

    private BindableCollection<IMainScreenTabItem> _tabs;
    private DataPresentationViewModel _dataPresentationVM;
    private ControlPanelViewModel _controlPanelVM;
    private object _selectedItem;
    private string _windowTitle;
    private readonly IWindowManager _windowManager;

    #endregion //Fields

    #region Properties

    public BindableCollection<IMainScreenTabItem> Tabs
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

    public string WindowTitle
    {
      get
      {
        return _windowTitle;
      }

      set
      {
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
      _dataPresentationVM = new DataPresentationViewModel();
      _controlPanelVM = new ControlPanelViewModel();
      Tabs = new BindableCollection<IMainScreenTabItem>();
      Tabs.Add(_dataPresentationVM);
      Tabs.Add(_controlPanelVM);
      ActivateItem(_dataPresentationVM);
      _windowManager = windowManager;
    }

    #endregion //Constructors

    #region Methods

    public void TabSelectionChanged() {
      if (SelectedItem.GetType() == typeof(ControlPanelViewModel)) {
        _windowManager.ShowWindow(new LoginViewModel());

      }
      if (SelectedItem.GetType() == typeof(DataPresentationViewModel)) {
      }
    }

    #endregion //Methods

  }
}
