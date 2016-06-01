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

    public IEnumerable<string> GetLocationNames() {
      return from probes in BasteleiContext.Probe
             select probes.locationname;
    }

    public int GetProbeIDByName(string name) {
      IEnumerable<int> probeIDs = from probes in BasteleiContext.Probe
                                  where probes.locationname == name
                                  select probes.id;

      return probeIDs.First();
    }
        public IEnumerable<Probe> GetUnverifiedProbes()
        {
            IEnumerable<Probe> unvProbes = from probes in BasteleiContext.Probe
                                           where probes.verified == false
                                           select probes;
            return unvProbes;
        }
    public void VerifyProbeByID(Probe paramProbe)
        {
            Probe result = (from probes in BasteleiContext.Probe
                                       where probes.id == paramProbe.id
                                       select probes).SingleOrDefault();
            result.verified = true;
        }
    private bool IsProbeTokenAssigned(string checkToken)
        {
            IEnumerable<string> probeTokens = from probes in BasteleiContext.Probe
                                              where probes.token == checkToken
                                              select probes.token;
            return probeTokens.Any();
        }
    public string GenerateProbeToken()
    {
            const string Alphabet = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string generatedToken;
            do
            {
                char[] chars = new char[62];
                for (int i = 0; i < 62; i++)
                {
                    chars[i] = Alphabet[RNG.Next(Alphabet.Length)];
                }
                generatedToken = new string(chars);
            }
            while (IsProbeTokenAssigned(generatedToken));
            return generatedToken;
        }

        public void AddProbe(int puserId, string plocationName)
        {
            Probe newProbe = new Probe
            {
                token = GenerateProbeToken(),
                locationname = plocationName,
                user_id = puserId,
                verified = false,
                
            };
            BasteleiContext.Probe.Add(newProbe);
        }
    }
    
    #endregion //Constructors

    #region Methods

    #endregion //Methods

  
}
