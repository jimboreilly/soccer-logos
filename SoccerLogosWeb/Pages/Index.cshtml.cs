using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerLogos;
using SoccerLogos.Types;

namespace SoccerLogosWeb.Pages {
  public class IndexModel : PageModel {

    public IndexModel() {
      Clubs = SoccerLogosMain.GetAllClubs();
    }
    public IEnumerable<Club> Clubs { get; set; }
    public SelectList Leagues { get; set; }
    public string SelectedLeague { get; set; }

    public void OnGet(string selectedLeague, string searchString) {

      //Clubs = HttpContext.Session.Get<IEnumerable<Club>>("AllClubs");
      //Clubs = SoccerLogosMain.GetAllClubs();
      var allLeagues = Clubs.Select(club => club.league);

      if (!String.IsNullOrEmpty(selectedLeague)) {
        Clubs = Clubs.Where(club => club.league == selectedLeague);
      }

      if (!String.IsNullOrEmpty(searchString)) {
        Clubs = Clubs.Where(club => club.name.Contains(searchString));
      }
      Leagues = new SelectList(allLeagues.Distinct().ToList());

    }
  }
}