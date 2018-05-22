using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace SoccerLogos.Core {
  public static class MakeApiRequest {

    private static readonly string baseurl = "http://api.football-data.org/v1/";

    public async static Task<string> GetHttpRequestResponseAsync(string url) {
      var request = WebRequest.Create(baseurl + url);
      var httpResponse = await request.GetResponseAsync();
      var response = parseWebResponseToString(httpResponse);
      httpResponse.Close();
      return response;
    }

    private static string parseWebResponseToString(WebResponse httpResponse) {
      var dataStream = httpResponse.GetResponseStream();
      var reader = new StreamReader(dataStream);
      var response = reader.ReadToEnd();

      reader.Close();

      return response;
    }


  }
}
