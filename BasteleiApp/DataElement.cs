using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp
{
    public class DataElement
    {
       public float temperature = 0;
       public float airpressure = 0;
       public float humidity = 0;
       public float altitude = 0;
       //public DateTime timestamp;

        DataElement(float tmp, float ap, float hum, float alt, /*DateTime time*/)
        {
            temperature = t;
            airpressure = ap;
            humidity = hum;
            altitude = alt;
            timestamp = time;
        }
    }
}
