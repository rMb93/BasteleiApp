using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasteleiApp.Models;

namespace BasteleiApp.Repositories {
  public interface IProbeRepository : IRepository<Probe> {
    IEnumerable<string> GetLocationNames();
    IEnumerable<Tuple<string, string>> GetUnverifiedProbes();
    int GetProbeIDByName(string Name);
    string GenerateProbeToken();
    void AddProbe(int userId, string locationName);
    void VerifyProbeByLocation(string mailadress);
  }
}
