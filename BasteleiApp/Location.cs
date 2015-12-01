using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace BasteleiApp
{
    public class Location
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



        public Location(string ID, string locname)

        {
            ProbeID = ID;
            LocationName = locname;
            
        }
        /*public Location(string jsonstr)
        {
            dynamic input = JsonConvert.DeserializeObject(jsonstr);
            this.LocationName = input.locationname;
            this.ProbeID = input.token;

        }*/
    }
}
