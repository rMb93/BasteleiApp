using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace BasteleiApp {
  class ActionHelper {

    #region Methods

    public static string HttpRequest(string url) {
      HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;

      using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse) {
        if (httpWebResponse.StatusCode != HttpStatusCode.OK) {
          throw new Exception(string.Format("Server error (HTTP {0}: {1}).",
              httpWebResponse.StatusCode, httpWebResponse.StatusDescription));
        }
        string rawData = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
        return rawData;
      }
    }

    #endregion //Methods

  }
}
