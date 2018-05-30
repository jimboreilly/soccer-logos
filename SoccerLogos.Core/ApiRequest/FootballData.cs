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

    /// <summary>
    /// Football data object to be used as a single instance to build urls for API requests
    /// </summary>
    public FootballData() { }

    /// <summary>
    /// Make the API request and deserialize the json response into the specified object type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="requestUrl"></param>
    /// <returns></returns>
    private T makeRequestAndDeserializeResults<T>(string requestUrl) {
      var task = api.GetHttpRequestResponseAsync(requestUrl);
      return JsonConvert.DeserializeObject<T>(task.Result);
    }

    /// <summary>
    /// Builds list of all competitions from the newest season of data available
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Competition> GetCompetitionsList() {
      var competitionsUrl = "/competitions";
      return makeRequestAndDeserializeResults<IEnumerable<Competition>>(competitionsUrl);
    }

    /// <summary>
    /// Gets the competition object from the given id number
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Competition GetCompetitionById(int id) {
      var competitionUrl = "/competitions/" + id.ToString();
      return makeRequestAndDeserializeResults<Competition>(competitionUrl);
    }

    /// <summary>
    /// Builds a league object from a competition id and name of the League
    /// </summary>
    /// <param name="id"></param>
    /// <param name="leagueName"></param>
    /// <returns></returns>
    public League GetLeaugeByCompetitionId(int id, string leagueName) {
      var clubsUrl = "/competitions/" + id.ToString() + "/teams";
      var league = makeRequestAndDeserializeResults<League>(clubsUrl);
      league.teams.ForEach(club => club.league = leagueName);
      return league;
    }

    /// <summary>
    /// Returns all clubs from the given list of competitions
    /// </summary>
    /// <param name="competitions"></param>
    /// <returns></returns>
    public IEnumerable<Club> GetAllClubsInListOfCompetitions(IEnumerable<Competition> competitions) {
      return competitions.SelectMany(comp => GetLeaugeByCompetitionId(comp.id, removeYearFromCaption(comp.caption)).teams);
    }

    /// <summary>
    /// Removes the 20xx/xx year label from the league caption string for pretty printing
    /// </summary>
    /// <param name="caption"></param>
    /// <returns></returns>
    private string removeYearFromCaption(string caption) {
      return caption.Substring(0, caption.LastIndexOf(' '));
    }

  }
}
