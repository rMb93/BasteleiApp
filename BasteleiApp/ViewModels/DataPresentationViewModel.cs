﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using BasteleiApp.Models;
using BasteleiApp.Repositories;

namespace BasteleiApp.ViewModels {
  public class DataPresentationViewModel : Screen {

    #region Fields

    private string _refreshBtnContent;
    private BindableCollection<DiagramViewModel> _diagrams;
    private DiagramViewModel _selectedDiagram;
    private string _locationsLbl;
    private BindableCollection<LocationViewModel> _locations;
    private string _timeSpanLbl;
    private BindableCollection<string> _timeSpans;
    private string _selectedTimeSpan;
    private int _timeIntervalInMinutes;
    private LocationViewModel _selectedLocation;
    private bool _progessRingIsActive = false;

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

    public bool ProgessRingIsActive {
      get {
        return _progessRingIsActive;
      }

      set {
        _progessRingIsActive = value;
        NotifyOfPropertyChange(() => ProgessRingIsActive);
      }
    }

    #endregion //Properties

    #region Constructors

    public DataPresentationViewModel() {
      DisplayName = "Presentation";
      RefreshBtnContent = "Refresh";     
      Diagrams = new BindableCollection<DiagramViewModel>();
      LocationsLbl = "Locations:";
      Locations = new BindableCollection<LocationViewModel>();
      GetLocations();
      TimeSpanLbl = "Timespan:";
      TimeSpans = new BindableCollection<string>();
      TimeSpans.Add("Year");
      TimeSpans.Add("Month");
      TimeSpans.Add("Week");
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
        throw new SystemException("Couldn't connect to DB", ex);
      }
    }

    private DateTime GetFromTime() {
      switch (SelectedTimeSpan) {
        case "Year":
          _timeIntervalInMinutes = 43200;
          return DateTime.Now.Subtract(TimeSpan.FromDays(365));
        case "Month":
          _timeIntervalInMinutes = 1440;
          return DateTime.Now.Subtract(TimeSpan.FromDays(30));
        case "Week":
          _timeIntervalInMinutes = 360;
          return DateTime.Now.Subtract(TimeSpan.FromDays(7));
        case "Day":
          _timeIntervalInMinutes = 60;
          return DateTime.Now.Subtract(TimeSpan.FromDays(1));
        case "Hour":
          _timeIntervalInMinutes = 5;
          return DateTime.Now.Subtract(TimeSpan.FromHours(1));
        default:
          return DateTime.Now;
      }
    }

    public void RefreshData() {
      ProgessRingIsActive = true;
      DateTime fromTime = GetFromTime();
      Diagrams.Clear();
      try {
        var unitOfWork = new UnitOfWork(new bastelei_ws());
        var probeID = unitOfWork.Probes.GetProbeIDByName(SelectedLocation.LocationBtn);
        Diagrams.Add(new DiagramViewModel("humidity", unitOfWork.Measurements.GetDateValuePairs(probeID,
                                          fromTime, "humidity", _timeIntervalInMinutes)));
        Diagrams.Add(new DiagramViewModel("temperature", unitOfWork.Measurements.GetDateValuePairs(probeID,
                                          fromTime, "temperature", _timeIntervalInMinutes)));
        Diagrams.Add(new DiagramViewModel("pressure", unitOfWork.Measurements.GetDateValuePairs(probeID,
                                          fromTime, "airpressure", _timeIntervalInMinutes)));
      }
      catch (Exception ex) {
                Exception blub;
                blub = ex;
      }
      ProgessRingIsActive = false;
    }

    #endregion //Methods
  }
}
