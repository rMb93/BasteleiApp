using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BasteleiApp.Models {
  class WeatherDataModel {

    #region Fields

    private List<ProbeData> _probes;

    #endregion //Fields

    #region Properties

    #endregion //Properties

    #region Constructors

    public WeatherDataModel() {
      JObject jObject = GetJsonObject();
      DeserializeJson(jObject);
    }

    #endregion //Constructors

    #region Methods

    private JObject GetJsonObject() {
      string rawJson = ActionHelper.HttpRequest("http://http://api.bastelei-ws.de/getData.php");
      JObject jsonObject = JObject.Parse(rawJson);
      return jsonObject;
    }

    private void DeserializeJson(JObject jObject) {

    }

    #endregion //Methods

  }
}
