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
    private BindableCollection<DiagramViewModel> _diagrams;
    private DiagramViewModel _selectedDiagram;
    private string _locationsLbl;
    private BindableCollection<LocationViewModel> _locations;
    private string _timeSpanLbl;
    private BindableCollection<string> _timeSpans;
    private string _selectedTimeSpan;
    private LocationViewModel _selectedLocation;

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

    public BindableCollection<string> TimeSpans {
      get {
        return _timeSpans;
      }

      set {
        _timeSpans = value;
        NotifyOfPropertyChange(() => TimeSpans);
      }
    }

    public string SelectedTimeSpan {
      get {
        return _selectedTimeSpan;
      }

      set {
        _selectedTimeSpan = value;
        NotifyOfPropertyChange(() => SelectedTimeSpan);
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

      TimeSpans = new BindableCollection<string>();
      TimeSpans.Add("Year");
      TimeSpans.Add("Month");
      TimeSpans.Add("Day");
      TimeSpans.Add("Hour");

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

    public void RefreshData() {
      DateTime fromTime = GetFromTime();
      Diagrams.Clear();
      try {
        var unitOfWork = new UnitOfWork(new bastelei_ws());
        var probeID = unitOfWork.Probes.GetProbeIDByName(SelectedLocation.LocationBtn);
        Diagrams.Add(new DiagramViewModel("humidity", unitOfWork.Measurements.GetDateValuePairs(probeID, fromTime, "humidity")));
        Diagrams.Add(new DiagramViewModel("temperature", unitOfWork.Measurements.GetDateValuePairs(probeID, fromTime, "temperature")));
        Diagrams.Add(new DiagramViewModel("pressure", unitOfWork.Measurements.GetDateValuePairs(probeID, fromTime, "airpressure")));
      }
      catch (Exception ex) {
        ;
      }
    }

    private DateTime GetFromTime() {
      switch (SelectedTimeSpan) {
        case "Year":
          return DateTime.Now.Subtract(TimeSpan.FromDays(365));
        case "Month":
          return DateTime.Now.Subtract(TimeSpan.FromDays(30));
        case "Day":
          return DateTime.Now.Subtract(TimeSpan.FromDays(1));
        case "Hour":
          return DateTime.Now.Subtract(TimeSpan.FromHours(1));
        default:
          return DateTime.Now;
      }
    }

    #endregion //Methods
  }
}
