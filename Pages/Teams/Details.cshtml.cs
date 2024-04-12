using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Diagnostics;
using League.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace League.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        //Atribute
        private readonly LeagueContext _leagueDB;

        //Propeties
        [BindProperty(SupportsGet =true)]
        public string Team {  get; set; }
        public Team Teamobj { get; set; }
        public List<Player> Players { get; set; }

        //Constructor
        public DetailsModel(LeagueContext leagueDB)
        {
            _leagueDB = leagueDB;
        }

        //Page methods
        public void OnGet()
        {
            var players = from p in _leagueDB.Players
                          where p.TeamId == this.Team
                          orderby p.Position, p.Number
                          select p;
            Players =players.ToList();

            var tname = from t in _leagueDB.Teams
                        where t.TeamId == this.Team
                        select t;
            this.Teamobj = tname.FirstOrDefault();
        }
    }
}
