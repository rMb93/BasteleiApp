using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp {
  public class UnverifiedProbe {

    #region Fields

    private string _mail;
    private string _name;
    private string _surname;
    private string _comment;
    private string _locationName;
    private string _token;

    #endregion //Fields

    #region Properties

    public string Mail {
      get {
        return _mail;
      }

      set {
        _mail = value;
      }
    }

    public string Name {
      get {
        return _name;
      }

      set {
        _name = value;
      }
    }

    public string Surname {
      get {
        return _surname;
      }

      set {
        _surname = value;
      }
    }

    public string Comment {
      get {
        return _comment;
      }

      set {
        _comment = value;
      }
    }

    public string LocationName {
      get {
        return _locationName;
      }

      set {
        _locationName = value;
      }
    }

    public string Token {
      get {
        return _token;
      }

      set {
        _token = value;
      }
    }

    #endregion //Properties

  }
}
