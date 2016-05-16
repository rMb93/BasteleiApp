using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp {
  public interface ITimespan {
    int CalculateTimespan();
    DateTime CalculateFromTime();
  }
}
