using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace BasteleiApp.ViewModels {
  public class ControlPanelViewModel : Screen {

    #region Fields
    
    private BindableCollection<object> _options;

    #endregion //Fields

    #region Properties

    public BindableCollection<object> Options
    {
      get
      {
        return _options;
      }

      set
      {
        _options = value;
      }
    }

    #endregion //Properties

    #region Constructors

    public ControlPanelViewModel() {
      DisplayName = "Control Panel";

      Options = new BindableCollection<object>();
      Options.Add(new RegisterProbeViewModel());
    }

    #endregion //Constructors

    #region Methods

    #endregion //Methods

  }
}
