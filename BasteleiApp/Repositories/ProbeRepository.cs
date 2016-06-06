using BasteleiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BasteleiApp.Repositories {
  public class ProbeRepository : Repository<Probe>, IProbeRepository {

    #region Fields
    private Random RNG = new Random();
    #endregion //Fields

    #region Properties

    public bastelei_ws BasteleiContext {
      get {
        return Context as bastelei_ws;
      }
    }

    #endregion //Properties

    #region Constructors

    public ProbeRepository(DbContext context) : base(context) {
    }

    #endregion //Constructors

    #region Methods

    public IEnumerable<string> GetLocationNames() {
      return from probes in BasteleiContext.Probe
             where probes.verified == true
             select probes.locationname;
    }

    public int GetProbeIDByName(string name) {
      IEnumerable<int> probeIDs = from probes in BasteleiContext.Probe
                                  where probes.locationname == name
                                  select probes.id;

      return probeIDs.First();
    }

    public IEnumerable<UnverifiedProbe> GetUnverifiedProbes() {
      IEnumerable<UnverifiedProbe> unverified = BasteleiContext.Probe
                                                .Where(probe => probe.verified == false)
                                                .Select(probe => new UnverifiedProbe {
                                                  Mail = probe.User.mailadress,
                                                  Name = probe.User.name,
                                                  Surname = probe.User.surname,
                                                  Comment = probe.comment,
                                                  LocationName = probe.locationname,
                                                  Token = probe.token
                                                });
      return unverified;
    }

    public void VerifyProbeByLocation(string locationName) {
      Probe result = (from probes in BasteleiContext.Probe
                      where probes.locationname == locationName
                      select probes).SingleOrDefault();
      result.verified = true;
    }

    public void UnverifyProbeByLocation(string locationName) {
      Probe result = (from probes in BasteleiContext.Probe
                      where probes.locationname == locationName
                      select probes).SingleOrDefault();
      result.verified = false;
    }

    private bool IsProbeTokenAssigned(string checkToken) {
      IEnumerable<string> probeTokens = from probes in BasteleiContext.Probe
                                        where probes.token == checkToken
                                        select probes.token;
      return probeTokens.Any();
    }

    public string GenerateProbeToken() {
      const string Alphabet = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      string generatedToken;
      do {
        char[] chars = new char[62];
        for (int i = 0; i < 62; i++) {
          chars[i] = Alphabet[RNG.Next(Alphabet.Length)];
        }
        generatedToken = new string(chars);
      }
      while (IsProbeTokenAssigned(generatedToken));
      return generatedToken;
    }

    public void AddProbe(int puserId, string plocationName, string pcomment) {
      Probe newProbe = new Probe {
        token = GenerateProbeToken(),
        locationname = plocationName,
        user_id = puserId,
        verified = false,
        comment = pcomment,
        location = "geoData"
      };
      BasteleiContext.Probe.Add(newProbe);
    }

    public void ChangeLocationNames(string locationName, string newLocationName) {
      Probe probe = (from probes in BasteleiContext.Probe
                   where probes.locationname == locationName
                   select probes).SingleOrDefault();
      probe.locationname = newLocationName;
    }
  }

  #endregion //Methods


}
