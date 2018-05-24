using SoccerLogos.Core.ApiRequest;
using SoccerLogos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLogos {
  public class SoccerLogosMain {

    private static readonly FootballData fbData = new FootballData();
    private static readonly IEnumerable<Club> clubs = fbData.GetAllClubsInListOfCompetitions(fbData.GetCompetitionsList());

    public static IEnumerable<string> GetAllClubNames() => clubs.Select(club => club.name).Distinct();
    public static string GetCrestImageUrlFromClubName(string name) => clubs.Single(club => club.name == name).crestUrl;
  }

}
