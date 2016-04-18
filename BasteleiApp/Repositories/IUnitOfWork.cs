using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp.Repositories {
	interface IUnitOfWork : IDisposable{
		IProbesRepository Probes { get; }
		IMeasurementsRepository Measurements { get; }
		int Complete();
	}
}
