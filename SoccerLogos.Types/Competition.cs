using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLogos.Types {
  public class Competition {
    public int id;
    public string caption;
    public string league;
    public int year;
    public int numberOfTeams;
    public int numberOfGames;

    public Competition(int id, string caption, string league, int year, int numberOfTeams, int numberOfGames) {
      this.id = id;
      this.caption = caption;
      this.league = league;
      this.year = year;
      this.numberOfTeams = numberOfTeams;
      this.numberOfGames = numberOfGames;
    }

    public override bool Equals(object obj) {
      var comp = (Competition)obj;
      return (this.id == comp.id)
        && (this.caption == comp.caption)
        && (this.league == comp.league)
        && (this.year == comp.year)
        && (this.numberOfTeams == comp.numberOfTeams)
        && (this.numberOfGames == comp.numberOfGames);
    }
  }
}
