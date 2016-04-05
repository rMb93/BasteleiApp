using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using BasteleiApp.Models;

namespace BasteleiApp.ViewModels {
  class MainViewModel : Screen {

    #region Fields

    private const string WindowTitleDefault = "bastelei";

    private string _windowTitle = WindowTitleDefault;
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

    public string WindowTitle
    {
      get { return _windowTitle; }
      set
      {
        _windowTitle = value;
        NotifyOfPropertyChange(() => WindowTitle);
      }
    }

    public bool CanLoadLocBtn
    {
      get { return true; }
    }

    public DiagramViewModel TempDiagram
    {
      get
      {
        return _tempDiagram;
      }

      set
      {
        _tempDiagram = value;
        NotifyOfPropertyChange(() => TempDiagram);
      }
    }

    public DiagramViewModel PressureDiagram
    {
      get
      {
        return _pressureDiagram;
      }

      set
      {
        _pressureDiagram = value;
        NotifyOfPropertyChange(() => PressureDiagram);
      }
    }

    public DiagramViewModel HumDiagram
    {
      get
      {
        return _humDiagram;
      }

      set
      {
        _humDiagram = value;
        NotifyOfPropertyChange(() => HumDiagram);
      }
    }

    public BindableCollection<DiagramViewModel> Diagrams
    {
      get
      {
        return _diagrams;
      }

      set
      {
        _diagrams = value;
        NotifyOfPropertyChange(() => Diagrams);
      }
    }

    public LocationViewModel DhLoc
    {
      get
      {
        return _dhLoc;
      }

      set
      {
        _dhLoc = value;
        NotifyOfPropertyChange(() => DhLoc);
      }
    }

    public LocationViewModel WohnheimLoc
    {
      get
      {
        return _wohnheimLoc;
      }

      set
      {
        _wohnheimLoc = value;
        NotifyOfPropertyChange(() => WohnheimLoc);
      }
    }

    public BindableCollection<LocationViewModel> Locations
    {
      get
      {
        return _locations;
      }

      set
      {
        _locations = value;
        NotifyOfPropertyChange(() => Locations);
      }
    }

    public string RefreshBtnContent
    {
      get
      {
        return _refreshBtnContent;
      }

      set
      {
        _refreshBtnContent = value;
        NotifyOfPropertyChange(() => RefreshBtnContent);
      }
    }    

    public DiagramViewModel SelectedDiagram
    {
      get
      {
        return _selectedDiagram;
      }

      set
      {
        _selectedDiagram = value;
        NotifyOfPropertyChange(() => SelectedDiagram);
      }
    }

    public BindableCollection<string> TimeSpansName
    {
      get
      {
        return _timeSpansName;
      }

      set
      {
        _timeSpansName = value;
        NotifyOfPropertyChange(() => TimeSpansName);
      }
    }

    public string SelectedTimeSpans
    {
      get
      {
        return _selectedTimeSpans;
      }

      set
      {
        _selectedTimeSpans = value;
        NotifyOfPropertyChange(() => SelectedTimeSpans);
      }
    }

    public string TimeSpanLbl
    {
      get
      {
        return _timeSpanLbl;
      }

      set
      {
        _timeSpanLbl = value;
        NotifyOfPropertyChange(() => TimeSpanLbl);
      }
    }

    public string LocationsLbl
    {
      get
      {
        return _locationsLbl;
      }

      set
      {
        _locationsLbl = value;
        NotifyOfPropertyChange(() => LocationsLbl);
      }
    }

    #endregion //Properties

    #region Constructors

    public MainViewModel() {
      RefreshBtnContent = "Refresh";

      TempDiagram = new DiagramViewModel("Temperature", GetTestData());
      PressureDiagram = new DiagramViewModel("Pressure", GetTestData());
      HumDiagram = new DiagramViewModel("Humidity", GetTestData());

      DhLoc = new LocationViewModel("DH");
      WohnheimLoc = new LocationViewModel("Wohnheim");

      Diagrams = new BindableCollection<DiagramViewModel>();
      Diagrams.Add(TempDiagram);
      Diagrams.Add(PressureDiagram);
      Diagrams.Add(HumDiagram);

      LocationsLbl = "Locations:";

      Locations = new BindableCollection<LocationViewModel>();
      Locations.Add(DhLoc);
      Locations.Add(WohnheimLoc);

      TimeSpanLbl = "Timespan:";

      TimeSpansName = new BindableCollection<string>();
      TimeSpansName.Add("Year");
      TimeSpansName.Add("Month");
      TimeSpansName.Add("Day");
      TimeSpansName.Add("Hour");

      WeatherDataModel model = new WeatherDataModel();
    }

    #endregion //Constructors

    #region Methods
    
    

    public void LoadLocBtn() {
      
    }

    private List<KeyValuePair<DateTime, double>> GetTestData() {
      List<KeyValuePair<DateTime, double>> test = new List<KeyValuePair<DateTime, double>>();
      test.Add(new KeyValuePair<DateTime, double>(new DateTime(2016, 08, 02),1.0));
      test.Add(new KeyValuePair<DateTime, double>(new DateTime(2016, 08, 03), 4.0));
      test.Add(new KeyValuePair<DateTime, double>(new DateTime(2016, 08, 04), 5.0));
      test.Add(new KeyValuePair<DateTime, double>(new DateTime(2016, 08, 05), 2.0));
      test.Add(new KeyValuePair<DateTime, double>(new DateTime(2016, 08, 06), 1.0));
      test.Add(new KeyValuePair<DateTime, double>(new DateTime(2016, 08, 07), 3.0));
      test.Add(new KeyValuePair<DateTime, double>(new DateTime(2016, 08, 08), 6.3));
      return test;
    }

    #endregion //Methods
  }
}
