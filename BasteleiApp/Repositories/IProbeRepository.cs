﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasteleiApp.Models;

namespace BasteleiApp.Repositories {
  public interface IProbeRepository : IRepository<Probe> {
    IEnumerable<string> GetLocationNames();
    int GetProbeIDByName(string Name);
  }
}
