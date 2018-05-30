using SoccerLogos.Core.ApiRequest;
using SoccerLogos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLogos {
  public static class SoccerLogosMain {

    //instance of FootballData for making requests
    private static readonly FootballData fbData = new FootballData();

    //Previously I wanted all soccer leagues the API had in the list, however the number of requests per minute was too high
    //private static readonly IEnumerable<Club> clubs = fbData.GetAllClubsInListOfCompetitions(fbData.GetCompetitionsList()).OrderBy(club => club.name);

    //specific list of the 2017/18 English league competitions' ids
    private static readonly List<int> englishCompetitionIds = new List<int> { 445, 446, 447, 448 };
    private static readonly IEnumerable<Competition> englishCompetitions = englishCompetitionIds.Select(id => fbData.GetCompetitionById(id));
    private static readonly IEnumerable<Club> clubs = fbData.GetAllClubsInListOfCompetitions(englishCompetitions).OrderBy(club => club.name);
    public static IEnumerable<string> GetAllClubNames() => clubs.Select(club => club.name).Distinct();
    public static IEnumerable<Club> GetAllClubs() => clubs;
    public static string GetCrestImageUrlFromClubName(string name) => clubs.Single(club => club.name == name).crestUrl;
  }

}
