using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BasteleiApp.Models;

namespace BasteleiApp.Repositories {
	class MeasurementsRepository : Repository<measurements>, IMeasurementsRepository {

		public MeasurementsRepository(DbContext context) : base(context) {
		}

    public Dictionary<DateTime, double> GetDateValuePairs(int probeID, TimeSpan timeSpan, string dataType) {
      throw new NotImplementedException();
    }
  }
}
