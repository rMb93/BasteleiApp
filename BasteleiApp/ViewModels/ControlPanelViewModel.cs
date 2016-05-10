using System;
using Caliburn.Micro;
using BasteleiApp.Repositories;
using BasteleiApp.Models;

namespace BasteleiApp.ViewModels {
  public class ControlPanelViewModel : Screen {

    #region Fields

    private BindableCollection<object> _options;

    #endregion //Fields

    #region Properties

    public BindableCollection<object> Options {
      get {
        return _options;
      }

      set {
        _options = value;
      }
    }

    #endregion //Properties

    #region Constructors

    public ControlPanelViewModel(string userAdress) {
      DisplayName = "Control";
      AddOptions(userAdress);
    }

    #endregion //Constructors

    #region Methods
    
    private void AddOptions(string userAdress) {
      int priviledge = FetchUserRights(userAdress);
      Options = new BindableCollection<object>();
      Options.Add(new RegisterProbeViewModel());
      if(priviledge == (int)Priviledge.Admin) {
        Options.Add(new VerifyProbeViewModel());
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
