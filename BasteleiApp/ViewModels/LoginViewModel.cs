using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using BasteleiApp.Repositories;
using BasteleiApp.Models;
using System.ComponentModel.Composition;

namespace BasteleiApp.ViewModels {
  [Export(typeof(MainViewModel))]
  class LoginViewModel : Screen {

    #region Fields

    private string _mailAdress;
    private string _password;
    private string _information;
    private readonly IWindowManager _windowManager;

    #endregion //Fields

    #region Properties

    public string MailAdress
    {
      get
      {
        return _mailAdress;
      }

      set
      {
        _mailAdress = value;
        NotifyOfPropertyChange(() => MailAdress);
      }
    }

    public string Password
    {
      get
      {
        return _password;
      }

      set
      {
        _password = value;
        NotifyOfPropertyChange(() => Password);
      }
    }

    public string Information
    {
      get
      {
        return _information;
      }

      set
      {
        _information = value;
        NotifyOfPropertyChange(() => Information);
      }
    }

    #endregion //Properties

    #region Constructors

    [ImportingConstructor]
    public LoginViewModel(IWindowManager windowManager) {
      DisplayName = "Login";
      Information = "Login if you want to use the control panel";
      _windowManager = windowManager;
    }

    #endregion //Constructors

    #region Methods

    public void Login() {
      try {
        var unitOfWork = new UnitOfWork(new bastelei_ws());
        string password = unitOfWork.Users.GetPassword(MailAdress);
        string passwordToTest = Tools.EncryptPassword(MailAdress, Password);
        if (Tools.PasswordsMatch(password, passwordToTest)) {
          Information = "You are logged in.";
          _windowManager.ShowWindow(new MainViewModel());
        }
        else {
          Information = "Wrong mail adress or password";
        }
      }
      catch (Exception ex) {
        Information = "Could not connect to database.";
      }
    }

    public void Register() {
      _windowManager.ShowWindow(new RegisterUserViewModel());
    }

    #endregion //Methods
  }
}
