using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace BasteleiApp.ViewModels {
  public class LocationViewModel : PropertyChangedBase {

    #region Fields

    private string _locationBtn;

    #endregion //Fields

    #region Properties

    public string LocationBtn
    {
      get
      {
        return _locationBtn;
      }

      set
      {
        _locationBtn = value;
        NotifyOfPropertyChange(() => LocationBtn);
      }
    }

    #endregion //Properties

    #region Constructors

    public LocationViewModel(string buttonContent) {
      LocationBtn = buttonContent;
    }

    #endregion //Constructors
  }
}
