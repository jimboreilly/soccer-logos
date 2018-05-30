using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLogos.Types {
  public class Club {

    [Display(Name = "Club")]
    public string name { get; set; }
    public string code { get; set; }
    public string shortName { get; set; }
    [Display(Name = "Crest")]
    public string crestUrl { get; set; }
    [Display(Name = "League")]
    public string league { get; set; }


    /// <summary>
    /// Type to represent a soccer club in any league
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <param name="shortName"></param>
    /// <param name="crestUrl"></param>
    public Club(string name, string code, string shortName, string crestUrl) {
      this.name = name;
      this.code = code;
      this.shortName = shortName;
      this.crestUrl = crestUrl;
    }

    public override bool Equals(object obj) {
      var club = (Club)obj;
      return (this.name == club.name)
        && (this.code == club.code)
        && (this.shortName == club.shortName)
        && (this.crestUrl == club.crestUrl)
        && (this.league == club.league);
    }
  }
}
