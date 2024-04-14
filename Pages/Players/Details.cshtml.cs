using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using League.Data;
using System.Linq;

namespace League.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly LeagueContext _leagueDB;
        public Player Player { get; set; }

        public DetailsModel(LeagueContext leagueDb)
        {
            {
                _leagueDB = leagueDb;
            }
        }
        public void OnGet(string ID)
        {
            var qry = from p in _leagueDB.Players
                where p.PlayerId == ID
                select p;
            this.Player = qry.FirstOrDefault();
        }
    }
}
