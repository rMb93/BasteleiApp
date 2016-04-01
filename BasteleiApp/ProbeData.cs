using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp {
  class ProbeData {

    #region Fields

    private string _token;
    private List<DataMeasurement> _data;

    #endregion //Fields

    #region Properties

    public string Token
    {
      get
      {
        return _token;
      }

      set
      {
        _token = value;
      }
    }

    internal List<DataMeasurement> Data
    {
      get
      {
        return _data;
      }

      set
      {
        _data = value;
      }
    }

    #endregion //Properties

    #region Constructors

    public ProbeData(string token) {
      Token = token;
    }

    #endregion //Constructors

    #region Methods

    public void AddDataMeasurement(DateTime time, double temp, double hum, double press, double alt) {
      Data.Add( new DataMeasurement(time, temp, hum, press, alt));
    }

    #endregion //Methods

  }
}
