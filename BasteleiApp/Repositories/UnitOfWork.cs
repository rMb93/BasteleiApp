using BasteleiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp.Repositories {
	class UnitOfWork : IUnitOfWork {

		#region Fields

		private readonly bastelei_ws _context;

		#endregion //Fields

		#region Properties

		public IMeasurementRepository Measurements {
			get; private set;
		}

		public IProbeRepository Probes {
			get; private set;
		}

		#endregion //Properties

		#region Constructors

		public UnitOfWork(bastelei_ws context) {
			_context = context;
			Probes = new ProbeRepository(_context);
			Measurements = new MeasurementRepository(_context);
		}

		#endregion //Constructors

		#region Methods
		
		public int Complete() {
			return _context.SaveChanges();
		}

		public void Dispose() {
			_context.Dispose();
		}

		#endregion //Methods

	}
}
