using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using BasteleiApp.Repositories;
using BasteleiApp.Models;

namespace BasteleiApp.ViewModels {
  class RegisterUserViewModel : Screen {

    #region Fields

    private string _name;
    private string _surname;
    private string _mailAdress;
    private string _password;
    private string _information;

    #endregion //Fields

    #region Properties

    public string Name {
      get {
        return _name;
      }

      set {
        _name = value;
        NotifyOfPropertyChange(() => Name);
      }
    }

    public string Surname {
      get {
        return _surname;
      }

      set {
        _surname = value;
        NotifyOfPropertyChange(() => Surname);
      }
    }

    public string MailAdress {
      get {
        return _mailAdress;
      }

      set {
        _mailAdress = value;
        NotifyOfPropertyChange(() => MailAdress);
      }
    }

    public string Password {
      get {
        return _password;
      }

      set {
        _password = value;
        NotifyOfPropertyChange(() => Password);
      }
    }

    public string Information {
      get {
        return _information;
      }

      set {
        _information = value;
        NotifyOfPropertyChange(() => Information);
      }
    }

    #endregion //Properties

    #region Constructors


    #endregion //Constructors

    #region Methods

    public void Register() {
      if (Name != null && Surname != null && MailAdress != null && Password != null) {
        RegisterUser();
      }
      else {
        Information = "Please fill out all text fields.";
      }
    }

    private void RegisterUser() {
      try {
        var unitOfWork = new UnitOfWork(new bastelei_ws());
        if (!unitOfWork.Users.MailExists(MailAdress)) {
          string encryptedPassword = Tools.EncryptPassword(MailAdress, Password);
          unitOfWork.Users.AddUser(Name, Surname, MailAdress, encryptedPassword);
          unitOfWork.Complete();
        }
        else {
          Information = "Mail adress does already exist.";
        }
      }
      catch (Exception ex) {
      }
    }

    #endregion //Methods
  }
}
