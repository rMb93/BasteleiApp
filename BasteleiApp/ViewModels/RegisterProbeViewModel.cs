using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows.Input;
using System.Windows;
using Microsoft.Maps.MapControl.WPF;
using BasteleiApp.Repositories;
using BasteleiApp.Models;

namespace BasteleiApp.ViewModels {
  public class RegisterProbeViewModel : Screen {

    #region Fields

    /*Location _location;
        string _name;
        string _street;
        int _houseNumber;
        int _zip;
        string _city;
    */ //Possible Extension to add more specific location information, would need modification in Database-Model
    string _locationName;
    string _mailAddress;
    string _information;

    #endregion //Fields

    #region Properties

    /*public Location Location {
      get {
        return _location;
      }

      set {
        _location = value;
        NotifyOfPropertyChange(() => Location);
      }
    }
    public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
    public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }
    public int HouseNumber
        {
            get { return _houseNumber; }
            set
            {
                _houseNumber = value;
                NotifyOfPropertyChange(() => HouseNumber);
            }
        }
    public int Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                NotifyOfPropertyChange(() => Zip);
            }
        }
    public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                NotifyOfPropertyChange(() => City);
            }
        }
        */
    public string LocationName {
      get { return _locationName; }
      set {
        _locationName = value;
        NotifyOfPropertyChange(() => LocationName);
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

    public RegisterProbeViewModel(string mailAdress) {
      DisplayName = "Register Probe";
      _mailAddress = mailAdress;
      //Location = new Location();
    }

    #endregion //Constructors

    #region Methods

    public void Submit() {
      if (LocationName != null) {
        RegisterProbe();
      }
    }

    private void RegisterProbe() {
      try {
        var unitOfWork = new UnitOfWork(new bastelei_ws());
        if (unitOfWork.Users.MailExists(_mailAddress)) {
          int uid = unitOfWork.Users.GetUserIDbyMail(_mailAddress);
          unitOfWork.Probes.AddProbe(uid, LocationName);
          unitOfWork.Complete();
          Information = "Probe registration successful.";
        }
        else {
          Information = "Mail Address does not exist.";
        }
      }
      catch (Exception ex) {

      }
    }

    #endregion //Methods

  }
}
