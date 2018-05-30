using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerLogos;
using SoccerLogos.Types;
using SoccerLogosWeb.Extensions;

namespace SoccerLogosWeb.Pages {
  public class IndexModel : PageModel {

    //string constant for indexing into HttpContext.Session
    private readonly string ALL_CLUBS_KEY = "AllClubs";

    public IndexModel() { }
    public IEnumerable<Club> Clubs { get; set; }
    public SelectList Leagues { get; set; }
    public string SelectedLeague { get; set; }

    public void OnGet(string selectedLeague, string searchString) {

      //try load list of all clubs from HttpContext.Session
      Clubs = HttpContext.Session.Get<IEnumerable<Club>>(ALL_CLUBS_KEY);
      if (Clubs == null) {
        //if not in memory, load from API and store in memory
        Clubs = SoccerLogosMain.GetAllClubs();
        HttpContext.Session.Set(ALL_CLUBS_KEY, Clubs);
      }

      var allLeagues = Clubs.Select(club => club.league);

      //filter clubs by the selected league and search text
      if (!String.IsNullOrEmpty(selectedLeague)) {
        Clubs = Clubs.Where(club => club.league == selectedLeague);
      }

      if (!String.IsNullOrEmpty(searchString)) {
        Clubs = Clubs.Where(club => club.name.ToLowerInvariant().Contains(searchString.ToLowerInvariant()));
      }

      //populate distinct leagues into selection list
      Leagues = new SelectList(allLeagues.Distinct().ToList());

    }
  }
}