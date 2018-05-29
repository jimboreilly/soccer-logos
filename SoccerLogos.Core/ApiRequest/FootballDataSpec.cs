using NUnit.Framework;
using SoccerLogos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLogos.Core.ApiRequest {
  public class FootballDataSpec {

    private FootballData fbData;
    private IEnumerable<Competition> competitions;
    private League prem;

    private const int premierLeague2017Id = 445;
    private const int countOfAllClubs = 392;

    [OneTimeSetUp]
    public void init() {
      fbData = new FootballData();
      competitions = fbData.GetCompetitionsList();
      prem = fbData.GetLeaugeByCompetitionId(premierLeague2017Id, "Premier League");
    }

    [SetUp]
    public void testInit() {
      System.Threading.Thread.Sleep(10); //wait 1ms to slow down request speed
    }

    [Test]
    public void GetAllCompetitionsInList() {
      Assert.AreEqual(17, competitions.Count());
    }

    [Test]
    public void PremierLeagueIsInListOfCompetitions() {
      var prem = new Competition(
        id: 445,
        caption: "Premier League 2017/18",
        league: "PL",
        year: 2017,
        numberOfTeams: 20,
        numberOfGames: 380);

      CollectionAssert.Contains(competitions, prem);
    }

    [Test]
    public void PremierLeagueHas20Clubs() {
      Assert.AreEqual(20, prem.teams.Count());
    }

    [Test]
    public void CrystalPalaceIsInPremierLeagueIn2017() {
      var crystalPalace = new Club(
        name: "Crystal Palace FC",
        code: "CRY",
        shortName: "Crystal",
        crestUrl: "http://upload.wikimedia.org/wikipedia/de/b/bf/Crystal_Palace_F.C._logo_(2013).png");

      CollectionAssert.Contains(prem.teams, crystalPalace);
    }

    [Test]
    public void CollapseAllClubsInListOfCompetetions() {
      var allClubs = fbData.GetAllClubsInListOfCompetitions(competitions);
      Assert.AreEqual(countOfAllClubs, allClubs.Count());
    }

  }
}
