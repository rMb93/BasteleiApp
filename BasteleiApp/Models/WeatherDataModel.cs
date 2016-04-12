using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BasteleiApp.Models {
  class WeatherDataModel : BaseModel {

    #region Fields

    private List<ProbeData> _probes;

    #endregion //Fields

    #region Properties

    #endregion //Properties

    #region Constructors

    public WeatherDataModel() {
      CreateDbConnection();
    }

    #endregion //Constructors

    #region Methods
    

    #endregion //Methods

  }
}
