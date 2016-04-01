using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp {
  class DataMeasurement {

    #region Fields

    private DateTime _timeStamp;
    private double _temperature;
    private double _humidity;
    private double _airpressure;
    private double _altitude;

    #endregion //Fields

    #region Properties

    public double Temperature
    {
      get
      {
        return _temperature;
      }

      set
      {
        _temperature = value;
      }
    }

    public double Humidity
    {
      get
      {
        return _humidity;
      }

      set
      {
        _humidity = value;
      }
    }

    public double Airpressure
    {
      get
      {
        return _airpressure;
      }

      set
      {
        _airpressure = value;
      }
    }

    public double Altitude
    {
      get
      {
        return _altitude;
      }

      set
      {
        _altitude = value;
      }
    }

    public DateTime TimeStamp
    {
      get
      {
        return _timeStamp;
      }

      set
      {
        _timeStamp = value;
      }
    }

    #endregion //Properties

    #region Constructors

    public DataMeasurement(DateTime time, double temp, double hum, double press, double alt) {
      TimeStamp = TimeStamp;
      Temperature = temp;
      Humidity = hum;
      Airpressure = press;
      Altitude = alt;
    }

    #endregion //Constructors
  }
}
