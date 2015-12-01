using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BasteleiApp
{
   public class LocationCollection : ObservableCollection<Location>
    {
        public void GetLocations()
        {
            //Hier soll später der Aufruf des http-Moduls erfolgen um eine Liste der abgelegten Locations zu erhalten, für jede Location soll ein Objekt zur Collection hinzugefügt werden

            Add(new Location("osdfiuewllvbiusiuhe", "DHBW"));
            Add(new Location("asfpjaspodjpasodsda", "Stefan"));

        }
        

        public void LoadLocationData(string locname, DataElementCollection DEC)
        {
            
        }
    }
}
