using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BasteleiApp
{
    public class DataElement
    {
        /*public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

       public float Temperature
        {
            get { return Temperature; }
            set { Temperature = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Temperature"));
            }
        }*/
        public float Temperature
        {
            get;
            set;
        }
        
       public float Airpressure
        {
            get;
            set;
        }
        public float Humidity
        {
            get;
            set;
        }
    public float Altitude
        {
            get;
            set;
        }

       public DateTime Timestamp
       {
            get;
            set;
        }

        
        public DataElement(string jsonstr)
        {
            
            dynamic input = JsonConvert.DeserializeObject(jsonstr);
            this.Temperature = (float)input.temperature;
            this.Airpressure = (float)input.airpressure;
            this.Humidity = (float)input.humidity;
            this.Altitude = (float)input.altitude;
            this.Timestamp = (DateTime)input.time;
        }
    }
}