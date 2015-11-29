using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace BasteleiApp
{
    public class LocationDataset
    {
        public string ProbeID
        {
            get;
            set;
        }
        public string LocationName
        {
            get;
            set;
        }
        public TimeSpan Timeframe
        {
            get;
            set;
        }



        public LocationDataset(string ID, string locname, TimeSpan tf)

        {
            ProbeID = ID;
            LocationName = locname;
            Timeframe = tf;
            
        }
        public LocationDataset(string jsonstr)
        {
            dynamic input = JsonConvert.DeserializeObject(jsonstr);
            LocationName = input.locationname;
            ProbeID = input.token;

        }
    }
}
