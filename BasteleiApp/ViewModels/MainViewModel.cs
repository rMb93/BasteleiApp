using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using BasteleiApp.Models;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace BasteleiApp.ViewModels {
  class MainViewModel : Screen {

    #region Fields

    private DataPresentationViewModel _dataPresentationVM;
    private ControlPanelViewModel _controlPanelVM;
    private object _selectedItem;
    private string _windowTitle;

    #endregion //Fields

    #region Properties

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

    public DataPresentationViewModel DataPresentationVM
    {
      get
      {
        return _dataPresentationVM;
      }

      set
      {
        _dataPresentationVM = value;
        NotifyOfPropertyChange(() => DataPresentationVM);
      }
    }

    public ControlPanelViewModel ControlPanelVM
    {
      get
      {
        return _controlPanelVM;
      }

      set
      {
        _controlPanelVM = value;
        NotifyOfPropertyChange(() => ControlPanelVM);
      }
    //}

    #endregion //Properties

    #region Constructors
    
    public MainViewModel() {
      WindowTitle = "bastelei";
      DataPresentationVM = new DataPresentationViewModel();
      ControlPanelVM = new ControlPanelViewModel();
    }

    #endregion //Constructors

    #region Methods

    public void TabSelectionChanged(SelectionChangedEventArgs e) {
      {
        var test = e.Source;
        if (SelectedItem.GetType() == typeof(ControlPanelViewModel)) {
        }
        if (SelectedItem.GetType() == typeof(DataPresentationViewModel)) {
        }
      }
    }

    #endregion //Methods

  }
}
