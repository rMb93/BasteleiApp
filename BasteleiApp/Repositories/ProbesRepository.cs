﻿using BasteleiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BasteleiApp.Repositories {
  class ProbesRepository : Repository<probes>, IProbesRepository {

    #region Fields

    #endregion //Fields

    #region Properties

    public bastelei_ws BasteleiContext {
      get {
        return Context as bastelei_ws;
      }
    }

    #endregion //Properties

    #region Constructors
    public ProbesRepository(DbContext context) : base(context) {
    }

    public IEnumerable<string> GetLocationNames() {
      return from probes in BasteleiContext.probes
             select probes.locationname;
    }

    public int GetProbeIDByName(string name) {
      IEnumerable<int> probeIDs = from probes in BasteleiContext.probes
                                  where probes.locationname == name
                                  select probes.id;

      return probeIDs.First();
    }

    #endregion //Constructors

    #region Methods

    #endregion //Methods

  }
}
