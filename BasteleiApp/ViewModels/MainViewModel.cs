
using BasteleiApp.Models;
using BasteleiApp.Repositories;
using Caliburn.Micro;
using System;
using System.Windows.Controls;

namespace BasteleiApp.ViewModels {
  class MainViewModel : Screen {

    #region Fields

    private DataPresentationViewModel _dataPresentationVM;
    private RegisterProbeViewModel _registerProbeVM;
    private VerifyProbeViewModel _verifyProbeVM;
    private bool _verifyProbeIsEnabled;
    private object _selectedItem;
    private string _windowTitle;

    #endregion //Fields

    #region Properties

    public string WindowTitle {
      get {
        return _windowTitle;
      }

      set {
        _windowTitle = value;
        NotifyOfPropertyChange(() => WindowTitle);
      }
    }

    public object SelectedItem {
      get {
        return _selectedItem;
      }

      set {
        _selectedItem = value;
        NotifyOfPropertyChange(() => SelectedItem);
      }
    }

    public DataPresentationViewModel DataPresentationVM {
      get {
        return _dataPresentationVM;
      }

      set {
        _dataPresentationVM = value;
        NotifyOfPropertyChange(() => DataPresentationVM);
      }
    }

    public RegisterProbeViewModel RegisterProbeVM {
      get {
        return _registerProbeVM;
      }

      set {
        _registerProbeVM = value;
        NotifyOfPropertyChange(() => RegisterProbeVM);
      }
    }

    public VerifyProbeViewModel VerifyProbeVM {
      get {
        return _verifyProbeVM;
      }

      set {
        _verifyProbeVM = value;
        NotifyOfPropertyChange(() => VerifyProbeVM);
      }
    }

    public bool VerifyProbeIsEnabled {
      get {
        return _verifyProbeIsEnabled;
      }

      set {
        _verifyProbeIsEnabled = value;
        NotifyOfPropertyChange(() => VerifyProbeIsEnabled);
      }
    }

    #endregion //Properties

    #region Constructors

    public MainViewModel(string userAdress) {
      WindowTitle = "bastelei";
      AddOptions(userAdress);
    }

    #endregion //Constructors

    #region Methods

    private void AddOptions(string userAdress) {      
      DataPresentationVM = new DataPresentationViewModel();
      RegisterProbeVM = new RegisterProbeViewModel();
      VerifyProbeVM = new VerifyProbeViewModel();
      int priviledge = FetchUserRights(userAdress);
      if (priviledge == (int)Priviledge.Admin) {
        VerifyProbeIsEnabled = true;
      }
    }

    private int FetchUserRights(string userAdress) {
      try {
        var unitOfWork = new UnitOfWork(new bastelei_ws());
        return unitOfWork.Users.GetUserRights(userAdress);
      }
      catch (Exception ex) {
        throw new SystemException("Couldn't connect to DB", ex);
      }
    }

    #endregion //Methods

  }
}
