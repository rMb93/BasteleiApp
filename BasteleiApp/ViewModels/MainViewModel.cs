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
    private DiagramViewModel _tempDiagram;
    private DiagramViewModel _pressureDiagram;
    private DiagramViewModel _humDiagram;
    private List<DiagramViewModel> _diagrams;

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

    internal DiagramViewModel TempDiagram
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

    internal DiagramViewModel PressureDiagram
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

    internal DiagramViewModel HumDiagram
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

    internal List<DiagramViewModel> Diagrams
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

    #endregion //Properties

    #region Constructors

    public MainViewModel() {
      TempDiagram = new DiagramViewModel("Temperature", GetTestData());
      PressureDiagram = new DiagramViewModel("Pressure", GetTestData());
      HumDiagram = new DiagramViewModel("Humidity", GetTestData());
      Diagrams = new List<DiagramViewModel>();
      Diagrams.Add(TempDiagram);
      Diagrams.Add(PressureDiagram);
      Diagrams.Add(HumDiagram);
      
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
