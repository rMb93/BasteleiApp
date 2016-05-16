using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows.Input;
using System.Windows;
using Microsoft.Maps.MapControl.WPF;

namespace BasteleiApp.ViewModels {
  public class RegisterProbeViewModel : Screen {

    #region Fields

    Location _location;

    #endregion //Fields

    #region Properties

    public Location Location {
      get {
        return _location;
      }

      set {
        _location = value;
        NotifyOfPropertyChange(() => Location);
      }
    }

    #endregion //Properties

    #region Constructors

    public RegisterProbeViewModel() {
      DisplayName = "Register Probe";
      Location = new Location();
    }

    #endregion //Constructors

    #region Methods

    public void Submit() {
      var test = Location;
    }

    #endregion //Methods

  }
}
