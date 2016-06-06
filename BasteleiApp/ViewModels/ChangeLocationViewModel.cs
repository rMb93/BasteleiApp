using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using BasteleiApp.Repositories;
using BasteleiApp.Models;

namespace BasteleiApp.ViewModels {
  class ChangeLocationViewModel : Screen{

    #region Fields

    private BindableCollection<LocationViewModel> _locations;
    private LocationViewModel _selectedLocation;
    private string _newLocationName;
    private string _information;    
    private string _comment;
    private string _userAdress;
    private Task _getLocationsTask;
    
    #endregion //Fields

    #region Properties

    public BindableCollection<LocationViewModel> Locations {
      get {
        return _locations;
      }

      set {
        _locations = value;
        NotifyOfPropertyChange(() => Locations);
      }
    }

    public string NewLocationName {
      get {
        return _newLocationName;
      }

      set {
        _newLocationName = value;
        NotifyOfPropertyChange(() => NewLocationName);
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

    public string Comment {
      get {
        return _comment;
      }

      set {
        _comment = value;
        NotifyOfPropertyChange(() => Comment);
      }
    }

    public LocationViewModel SelectedLocation {
      get {
        return _selectedLocation;
      }

      set {
        _selectedLocation = value;
        NotifyOfPropertyChange(() => SelectedLocation);
      }
    }

    #endregion //Properties

    #region Constructors

    public ChangeLocationViewModel(string userAdress) {
      DisplayName = "Change Location";
      Locations = new BindableCollection<LocationViewModel>();
      _userAdress = userAdress;
      GetLocationsForUser();
    }

    #endregion //Constructors

    #region Methods

    private void GetLocationsForUser() {
      try {
        if (Locations.Count != 0) {
          Locations.Clear();
        }
        var unitOfWork = new UnitOfWork(new bastelei_ws());
        var locNames = unitOfWork.Users.GetUserLocationNames(_userAdress);
        foreach (var name in locNames) {
          Locations.Add(new LocationViewModel(name));
        }
        unitOfWork.Complete();
      }
      catch (Exception ex) {
        throw new SystemException("Couldn't connect to DB", ex);
      }
    }

    public void RefreshLocations() {
      _getLocationsTask = new Task(GetLocationsForUser);
      _getLocationsTask.Start();
    }

    public void Submit() {
      try {
        var unitOfWork = new UnitOfWork(new bastelei_ws());
        unitOfWork.Probes.ChangeLocationNames(SelectedLocation.LocationBtn, NewLocationName);
        unitOfWork.Probes.UnverifyProbeByLocation(SelectedLocation.LocationBtn);
        unitOfWork.Complete();
        Information = "Location Name changed. Please wait for varification";
      }
      catch (Exception ex) {
        throw new SystemException("Couldn't connect to DB", ex);
      }
    }

    #endregion //Methods
  }
}
