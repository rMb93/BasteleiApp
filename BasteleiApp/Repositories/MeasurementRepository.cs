using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BasteleiApp.Models;

namespace BasteleiApp.Repositories {
	public class MeasurementRepository : Repository<Measurement>, IMeasurementRepository {
    
		public MeasurementRepository(DbContext context) : base(context) {

		}

    public bastelei_ws BasteleiContext {
      get {
        return Context as bastelei_ws;
      }
    }

    public List<KeyValuePair<DateTime, double?>> GetDateValuePairs(int probeID, DateTime fromTime, string dataType, int interval) {
      var query = (from m in BasteleiContext.Measurement
                  where m.time > fromTime && 
                      m.probe_id == probeID &&
                      m.datatype == dataType
                  select new { m.time, m.value });

      List<KeyValuePair<DateTime, double?>> keyValPairs = new List<KeyValuePair<DateTime, double?>>();
      DateTime tempTime = fromTime;
      foreach (var q in query) {
        if (q.time >= tempTime) {
          tempTime = q.time;
          tempTime = tempTime.Add(TimeSpan.FromMinutes(interval));          
          keyValPairs.Add(new KeyValuePair<DateTime, double?>(q.time, q.value));
        }
      }
      return keyValPairs;
    }
  }
}
