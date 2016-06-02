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
  public class VerifyProbeViewModel : Screen {

    #region Fields

    ObservableCollection<UnverifiedProbe> _probeList = new ObservableCollection<UnverifiedProbe>();
    UnverifiedProbe _selectedProbe;

    #endregion //Fields

    #region Properties

    public ObservableCollection<UnverifiedProbe> ProbeList {
      get { return _probeList; }
      set {
        _probeList = value;
        NotifyOfPropertyChange(() => ProbeList);
      }
    }
    public UnverifiedProbe SelectedProbe {
      get { return _selectedProbe; }
      set {
        _selectedProbe = value;
        NotifyOfPropertyChange(() => SelectedProbe);
      }
    }

    #endregion //Properties

    #region Constructors

    public VerifyProbeViewModel() {
      DisplayName = "Verify Probe";
      LoadProbes();
    }

    #endregion //Constructors

    #region Methods

    public void LoadProbes() {
      try {
        ProbeList.Clear();
        UnitOfWork unitOfWork = new UnitOfWork(new bastelei_ws());
        var probes = unitOfWork.Probes.GetUnverifiedProbes();
        foreach (UnverifiedProbe item in probes) {
          ProbeList.Add(item);
        }
        unitOfWork.Complete();
      }
      catch {

      }
    }

    public void Verify() {
      UnitOfWork unitOfWork = new UnitOfWork(new bastelei_ws());
      if (SelectedProbe != null) {
        unitOfWork.Probes.VerifyProbeByLocation(SelectedProbe.LocationName);
        unitOfWork.Complete();
        //TODO Information Text
      }
      else {
        //Todo Information nicht erfolgreich
      }
      LoadProbes();
    }

    #endregion //Methods

  }
}
