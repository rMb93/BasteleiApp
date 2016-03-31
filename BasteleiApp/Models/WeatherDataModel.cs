using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace BasteleiApp {
  class WeatherDataModel {

    #region Fields


    #endregion //Fields

    #region Properties


    #endregion //Properties

    #region Constructors

    public WeatherDataModel() {
      GetJsonData();
    }

    #endregion //Constructors

    #region Methods

    private void GetJsonData() {
      string rawJson = ActionHelper.HttpRequest("http://api.bastelei-ws.de/getData.php");
      var json = JObject.Parse(rawJson);

    }

    #endregion //Methods
  }
}
