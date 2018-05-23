using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SoccerLogos.Types;

namespace SoccerLogos.Core.ApiRequest {
  public class FootballData {

    private readonly static MakeApiRequest api = new MakeApiRequest();

    private T makeRequestAndDeserializeResults<T>(string requestUrl) {
      var task = api.GetHttpRequestResponseAsync(requestUrl);
      return JsonConvert.DeserializeObject<T>(task.Result);
    }

    public IEnumerable<Competition> GetCompetitionsList() {
      var competitionsUrl = "/competitions";
      return makeRequestAndDeserializeResults<IEnumerable<Competition>>(competitionsUrl);
    }

    public League GetLeaugeByCompetitionId(int id) {
      var clubsUrl = "/competitions/" + id.ToString() + "/teams";
      return makeRequestAndDeserializeResults<League>(clubsUrl);
    }

    public IEnumerable<Club> GetAllClubsInListOfCompetitions(IEnumerable<Competition> competitions) {
      return competitions.SelectMany(comp => GetLeaugeByCompetitionId(comp.id).teams);
    }

  }
}
