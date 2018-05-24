using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SoccerLogos.Core {
  public class MakeApiRequest {

    private readonly string apiKey;
    private readonly string configFileName = "config.json";
    private readonly string baseurl = "http://api.football-data.org/v1/";

    public MakeApiRequest() {
      //try to load the api key from the config file else requests are limited
      var configLocation = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
      var configPath = configLocation + configFileName;
      if (File.Exists(configPath)) {
        JObject config = JObject.Parse(File.ReadAllText(configPath));
        this.apiKey = config.Property("key").Value.ToString();
      }
      else this.apiKey = null;
    }

    public async Task<string> GetHttpRequestResponseAsync(string url) {
      var httpRequest = (HttpWebRequest)WebRequest.Create(baseurl + url);

      //limited to 50 requests/day without authentication
      if (this.apiKey != null) {
        httpRequest.PreAuthenticate = true;
        httpRequest.Headers.Add("X-Auth-Token", apiKey);
      }
      var httpResponse = await httpRequest.GetResponseAsync();
      var response = parseWebResponseToString(httpResponse);
      httpResponse.Close();
      return response;
    }

    private string parseWebResponseToString(WebResponse httpResponse) {
      var dataStream = httpResponse.GetResponseStream();
      var reader = new StreamReader(dataStream);
      var response = reader.ReadToEnd();

      reader.Close();

      return response;
    }

  }
}
