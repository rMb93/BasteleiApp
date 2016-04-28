using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace BasteleiApp.ViewModels {
  class RegisterUserViewModel : Screen{

    #region Fields

    private string _name;
    private string _surname;
    private string _mailAdress;
    private string _password;

    #endregion //Fields

    #region Properties

    public string Name
    {
      get
      {
        return _name;
      }

      set
      {
        _name = value;
        NotifyOfPropertyChange(() => Name);
      }
    }

    public string Surname
    {
      get
      {
        return _surname;
      }

      set
      {
        _surname = value;
        NotifyOfPropertyChange(() => Surname);
      }
    }

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

    #endregion //Properties

    #region Constructors


    #endregion //Constructors

    #region Methods

    public void Register() {

    }

    #endregion //Methods
  }
}
