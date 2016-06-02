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

    ObservableCollection<Tuple<string, string>> _probeList = new ObservableCollection<Tuple<string, string>>();
    Tuple<string, string> _selectedProbe;

    #endregion //Fields

    #region Properties

    public ObservableCollection<Tuple<string, string>> ProbeList {
      get { return _probeList; }
      set {
        _probeList = value;
        NotifyOfPropertyChange(() => ProbeList);
      }
    }
    public Tuple<string, string> SelectedProbe {
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
        foreach (Tuple<string, string> item in probes) {
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
        unitOfWork.Probes.VerifyProbeByLocation(SelectedProbe.Item2);
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
