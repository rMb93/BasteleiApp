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

    public bastelei_ws BasteleiContext {
      get {
        return Context as bastelei_ws;
      }
    }

    public List<KeyValuePair<DateTime, double?>> GetDateValuePairs(int probeID, DateTime fromTime, string dataType) {
      var query = (from m in BasteleiContext.measurements
               where m.time > fromTime && 
                      m.probe_id == probeID &&
                      m.datatype == dataType
               select new { m.time, m.value });
      var keyValpairs = query.AsEnumerable()
      .Select(item => new KeyValuePair<DateTime, double?>(item.time, item.value))
      .ToList();
      return keyValpairs;
    }
  }
}
