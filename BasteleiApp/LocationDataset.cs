using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp
{
    public class LocationDataset
    {
        public string probeID = "";
        public string locationName = "";
        public TimeSpan timeframe;
        public DataElement[] allData;

        LocationDataset(string ID, string locname, TimeSpan tf)
        {
            probeID = ID;
            locationName = locname;
            timeframe = tf;
            //TimeSpan in int umwandeln, um sie dem Array als Größe zu übergeben, Ersatz erstmal i
            int i = 2;
            allData = new DataElement[i];
            for (int j = 0; j < i; j++)
            {
                //Hier werden die geparsten Daten zu DataElement Objekten. Diese sollen am Ende dargestellt werden.
            }
        }
    }
}

