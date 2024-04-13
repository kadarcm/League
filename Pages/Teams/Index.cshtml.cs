using League.Data;
using League.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace League.Pages.Teams
{
    public class IndexModel : PageModel
    {
        // atributes
        private readonly LeagueContext _leagueDB;

        // Constructor
        public IndexModel(LeagueContext leagueDB)
        {
            _leagueDB = leagueDB;
        }

        // Properties
        public List<Division> Divisions { get; set; }
        [BindProperty(SupportsGet =true)]
        public string Conf  {  get; set; } = "AFC";
        
        [BindProperty(SupportsGet =true)]
        public List<SelectListItem> TeamSelect { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Fav { get; set; }

        public async Task<IActionResult> OnGet()
        {
            
            var qry = from d in _leagueDB.Divisions.Include("Teams")
                      where d.ConferenceId == this.Conf
                      select d;

            this.Divisions = await qry.ToListAsync();
            ;
            foreach (Division d in this.Divisions)
            {
                foreach (Team t in d.Teams)
                {
                    TeamSelect.Add(new SelectListItem { Text = t.Name, Value = t.TeamId, Disabled = false });
                }
            }
            if (Fav != null)
            {
                HttpContext.Session.SetString("_Favorite", Fav);
            }
            else
            {
                Fav = HttpContext.Session.GetString("_Favorite");
            }
            return Page();

             

        }

        public IActionResult OnPost()
         {
            //Response.Cookies.Append("FavTeams", Fav);
            return Page();
        }
    }
}
