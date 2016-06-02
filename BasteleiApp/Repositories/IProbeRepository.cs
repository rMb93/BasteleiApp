using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasteleiApp.Models;

namespace BasteleiApp.Repositories {
  public interface IProbeRepository : IRepository<Probe> {
    IEnumerable<string> GetLocationNames();
    IEnumerable<UnverifiedProbe> GetUnverifiedProbes();
    int GetProbeIDByName(string Name);
    string GenerateProbeToken();
    void AddProbe(int userId, string locationName, string comment);
    void VerifyProbeByLocation(string mailadress);
  }
}
