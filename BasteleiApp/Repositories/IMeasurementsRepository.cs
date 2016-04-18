using BasteleiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp.Repositories {
	interface IMeasurementsRepository : IRepository<measurements> {
    Dictionary<DateTime, double> GetDateValuePairs(int probeID, TimeSpan timeSpan, string dataType);
	}
}
