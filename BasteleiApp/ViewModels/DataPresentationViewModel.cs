using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using BasteleiApp.Models;
using BasteleiApp.Repositories;

namespace BasteleiApp.ViewModels {
  class DataPresentationViewModel : Screen {

    #region Fields

    private string _refreshBtnContent;
    private DiagramViewModel _tempDiagram;
    private DiagramViewModel _pressureDiagram;
    private DiagramViewModel _humDiagram;
    private BindableCollection<DiagramViewModel> _diagrams;
    private DiagramViewModel _selectedDiagram;
    private string _locationsLbl;
    private LocationViewModel _dhLoc;
    private LocationViewModel _wohnheimLoc;
    private BindableCollection<LocationViewModel> _locations;
    private string _timeSpanLbl;
    private BindableCollection<string> _timeSpansName;
    private string _selectedTimeSpans;

    #endregion //Fields

    #region Properties

    public bool CanRefresh {
      get { return true; }
    }

    public BindableCollection<DiagramViewModel> Diagrams {
      get {
        return _diagrams;
      }

      set {
        _diagrams = value;
        NotifyOfPropertyChange(() => Diagrams);
      }
    }
    
    public BindableCollection<LocationViewModel> Locations {
      get {
        return _locations;
      }

      set {
        _locations = value;
        NotifyOfPropertyChange(() => Locations);
      }
    }

    public string RefreshBtnContent {
      get {
        return _refreshBtnContent;
      }

      set {
        _refreshBtnContent = value;
        NotifyOfPropertyChange(() => RefreshBtnContent);
      }
    }

    public DiagramViewModel SelectedDiagram {
      get {
        return _selectedDiagram;
      }

      set {
        _selectedDiagram = value;
        NotifyOfPropertyChange(() => SelectedDiagram);
      }
    }

    public BindableCollection<string> TimeSpansName {
      get {
        return _timeSpansName;
      }

      set {
        _timeSpansName = value;
        NotifyOfPropertyChange(() => TimeSpansName);
      }
    }

    public string SelectedTimeSpans {
      get {
        return _selectedTimeSpans;
      }

      set {
        _selectedTimeSpans = value;
        NotifyOfPropertyChange(() => SelectedTimeSpans);
      }
    }

    public string TimeSpanLbl {
      get {
        return _timeSpanLbl;
      }

      set {
        _timeSpanLbl = value;
        NotifyOfPropertyChange(() => TimeSpanLbl);
      }
    }

    public string LocationsLbl {
      get {
        return _locationsLbl;
      }

      set {
        _locationsLbl = value;
        NotifyOfPropertyChange(() => LocationsLbl);
      }
    }

    #endregion //Properties

    #region Constructors

    public DataPresentationViewModel() {
      DisplayName = "Data Presentation";

      RefreshBtnContent = "Refresh";

      //TempDiagram = new DiagramViewModel("Temperature", GetTestData(3));
      //PressureDiagram = new DiagramViewModel("Pressure", GetTestData(3));
      //HumDiagram = new DiagramViewModel("Humidity", GetTestData(3));
      

      Diagrams = new BindableCollection<DiagramViewModel>();

      LocationsLbl = "Locations:";

      Locations = new BindableCollection<LocationViewModel>();
      GetLocations();

      TimeSpanLbl = "Timespan:";

      TimeSpansName = new BindableCollection<string>();
      TimeSpansName.Add("Year");
      TimeSpansName.Add("Month");
      TimeSpansName.Add("Day");
      TimeSpansName.Add("Hour");

    }

    #endregion //Constructors

    #region Methods

    private void GetLocations() {
      try {
        var unitOfWork = new UnitOfWork(new bastelei_ws());
        var locNames = unitOfWork.Probes.GetLocationNames();
        foreach (var name in locNames) {
          Locations.Add(new LocationViewModel(name));
        }
      }
      catch (Exception ex) {
        ;
      }
    }

    public void Refresh() {
      try {
        var unitOfWork = new UnitOfWork(new bastelei_ws());
        var test = unitOfWork.Probes.GetAll();
      }
      catch (Exception ex) {
        ;
      }
    }

    #endregion //Methods
  }
}
