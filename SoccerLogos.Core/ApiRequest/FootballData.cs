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

    public FootballData() { }

    private T makeRequestAndDeserializeResults<T>(string requestUrl) {
      var task = api.GetHttpRequestResponseAsync(requestUrl);
      return JsonConvert.DeserializeObject<T>(task.Result);
    }

    public IEnumerable<Competition> GetCompetitionsList() {
      var competitionsUrl = "/competitions";
      return makeRequestAndDeserializeResults<IEnumerable<Competition>>(competitionsUrl);
    }

    public Competition GetCompetitionById(int id) {
      var competitionUrl = "/competitions/" + id.ToString();
      return makeRequestAndDeserializeResults<Competition>(competitionUrl);
    }

    public League GetLeaugeByCompetitionId(int id, string leagueName) {
      var clubsUrl = "/competitions/" + id.ToString() + "/teams";
      var league = makeRequestAndDeserializeResults<League>(clubsUrl);
      league.teams.ForEach(club => club.league = leagueName);
      return league;
    }

    public IEnumerable<Club> GetAllClubsInListOfCompetitions(IEnumerable<Competition> competitions) {
      return competitions.SelectMany(comp => GetLeaugeByCompetitionId(comp.id, removeYearFromCaption(comp.caption)).teams);
    }

    private string removeYearFromCaption(string caption) {
      return caption.Substring(0, caption.LastIndexOf(' '));
    }

  }
}
