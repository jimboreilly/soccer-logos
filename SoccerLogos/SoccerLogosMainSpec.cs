using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLogos {
  public class SoccerLogosMainSpec {

    private IEnumerable<string> clubNames;

    [OneTimeSetUp]
    public void init() {
      clubNames = SoccerLogosMain.GetAllClubNames();
    }

    [Test]
    public void ListOfClubNamesContainsPremierLeagueTeams() {
      CollectionAssert.Contains(clubNames, "Manchester United FC");
      CollectionAssert.Contains(clubNames, "Manchester City FC");
    }

    [Test]
    public void ListOfClubNamesContainsBundesligaTeams() {
      CollectionAssert.Contains(clubNames, "Borussia Dortmund");
      CollectionAssert.Contains(clubNames, "FC Bayern München");
    }

    [Test]
    public void ListOfClubNamesContainsLigue1Teams() {
      CollectionAssert.Contains(clubNames, "Paris Saint-Germain");
      CollectionAssert.Contains(clubNames, "Olympique de Marseille");
    }
  }
}
