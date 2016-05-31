using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BasteleiApp.Models;
using BasteleiApp.Repositories;

namespace BasteleiApp.ViewModels {
  public class VerifyProbeViewModel : Screen{

        #region Fields
        ObservableCollection<Probe> _probeList = new ObservableCollection<Probe>();
    #endregion //Fields

    #region Properties
        public ObservableCollection<Probe> ProbeList
        {
            get { return _probeList; }
            set
            {
                _probeList = value;
                NotifyOfPropertyChange(() => ProbeList);
            }
        }
    #endregion //Properties

    #region Constructors
        
    public VerifyProbeViewModel()
    {
      DisplayName = "Verify Probe";
      LoadProbes();
    }

        #endregion //Constructors

        #region Methods
        public void LoadProbes()
        {
            ProbeList.Clear();
            UnitOfWork unitOfWork = new UnitOfWork(new bastelei_ws());
            var probes = unitOfWork.Probes.GetAllProbes();
            foreach (Probe item in probes)
            {
                ProbeList.Add(item);
            }
            unitOfWork.Complete();
        }
    #endregion //Methods

  }
}
