using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace BasteleiApp
{
    public class Convert
    {
        string input;

        void convert(string j)
        {
            dynamic output = JsonConvert.DeserializeObject("{'temperature':17.100000381469728,'humidity':40.70000076293945,'airpressure':99423.0,'altitude':159.31381225585938}");
            System.Console.WriteLine(output);
        }
    }
}
