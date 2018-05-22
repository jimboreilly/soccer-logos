using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLogos.Types {
  public class Club {
    public string name;
    public string code;
    public string shortName;
    public string crestUrl;

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
        && (this.crestUrl == club.crestUrl);
    }
  }
}
