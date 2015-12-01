using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BasteleiApp
{
    public class DataElementCollection : ObservableCollection<DataElement>
    {
        public void GetData(string[] jsonlist)
        {
            foreach(string item in jsonlist)
            {
                Add(new DataElement(item));
                
            }
        }
    }
}
