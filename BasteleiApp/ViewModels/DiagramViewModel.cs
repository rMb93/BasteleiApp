using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace BasteleiApp.ViewModels {
  class DiagramViewModel : PropertyChangedBase {

    #region Fields

    List<KeyValuePair<DateTime, double>> _weatherData = new List<KeyValuePair<DateTime, double>>();
    string _title;

    #endregion //Fields

    #region Properties    

    public List<KeyValuePair<DateTime, double>> WeatherData
    {
      get
      {
        return _weatherData;
      }

      set
      {
        _weatherData = value;
        NotifyOfPropertyChange(() => WeatherData);
      }
    }

    public string Title
    {
      get
      {
        return _title;
      }

      set
      {
        _title = value;
        NotifyOfPropertyChange(() => Title);
      }
    }

    #endregion //Properties

    #region Constructors

    public DiagramViewModel(string title, List<KeyValuePair<DateTime, double>> weatherData) {
      Title = title;
      WeatherData = weatherData;
    }

    #endregion //Constructors
  }
}
