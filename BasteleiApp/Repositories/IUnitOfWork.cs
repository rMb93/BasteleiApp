using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp.Repositories {
	interface IUnitOfWork : IDisposable{
		IProbeRepository Probes { get; }
		IMeasurementRepository Measurements { get; }
		int Complete();
	}
}
