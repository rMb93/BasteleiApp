using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp.Timespan {
  public class TimespanFactory {

    public ITimespan GetTimespanObject(string selectedTimeSpan) {
      switch (selectedTimeSpan) {
        case "Year":
          return new YearTimespan();
        case "Month":
          return new MonthTimespan();
        case "Week":
          return new WeekTimespan();
        case "Day":
          return new DayTimespan();
        case "Hour":
          return new HourTimespan();
        default:
          return null;
      }
    }
  }
}
