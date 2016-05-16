using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp.Timespan {
  class WeekTimespan : ITimespan {
    public DateTime CalculateFromTime() {
      return DateTime.Now.Subtract(TimeSpan.FromDays(7));
    }

    public int CalculateTimespan() {
      return 360;
    }
  }
}
