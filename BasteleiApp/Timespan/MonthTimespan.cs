using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp.Timespan {
  class MonthTimespan : ITimespan {
    public DateTime CalculateFromTime() {
      return DateTime.Now.Subtract(TimeSpan.FromDays(30));
    }

    public int CalculateTimespan() {
      return 1440;
    }
  }
}
