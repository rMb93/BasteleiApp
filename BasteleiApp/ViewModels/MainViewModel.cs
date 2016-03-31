using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using BasteleiApp.ViewModels;

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
    private LocationViewModel _dhLoc;
    private LocationViewModel _wohnheimLoc;
    private BindableCollection<LocationViewModel> _locations;

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

      Locations = new BindableCollection<LocationViewModel>();
      Locations.Add(DhLoc);
      Locations.Add(WohnheimLoc);
      
    }

    #endregion //Constructors

    #region Methods

    public void LoadLocBtn() {
      WindowTitle = "blub";
    }

    private List<KeyValuePair<DateTime, double>> GetTestData() {
      List<KeyValuePair<DateTime, double>> test = new List<KeyValuePair<DateTime, double>>();
      test.Add(new KeyValuePair<DateTime, double>(DateTime.Now, 1.0));
      test.Add(new KeyValuePair<DateTime, double>(DateTime.Now, 4.0));
      test.Add(new KeyValuePair<DateTime, double>(DateTime.Now, 5.0));
      test.Add(new KeyValuePair<DateTime, double>(DateTime.Now, 2.0));
      test.Add(new KeyValuePair<DateTime, double>(DateTime.Now, 1.0));
      test.Add(new KeyValuePair<DateTime, double>(DateTime.Now, 3.0));
      test.Add(new KeyValuePair<DateTime, double>(DateTime.Now, 6.3));
      return test;
    }

    #endregion //Methods
  }
}
