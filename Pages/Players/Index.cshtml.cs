using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using League.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Net.NetworkInformation;

namespace League.Pages.Players
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

        //Properties
        [BindProperty(SupportsGet =true)]
        public string Pname { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Tname { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Pos { get; set; }

        public List<SelectListItem> TeamNames { get; set; }
        public List<SelectListItem> Postions { get; set; }
        public List<Player> Players { get; set; }

        public IActionResult OnGet()
        {
            
            
            var qry = from p in _leagueDB.Players
                where (p.Team.Name == Tname || Tname==null)   
                where (p.Name.Contains(Pname) || Pname==null)
                where (p.Position == Pos || Pos == null)
                select p;
            Players = qry.ToList();

            var qry1 = from t in _leagueDB.Teams
                       select new SelectListItem( t.Name, t.Name);
            TeamNames = new  (qry1.ToList());

            var qr2 = from p in _leagueDB.Players
                      select p.Position;
            List<string> result = qr2.ToList();
            List<string> testStr= new List<string>();

            Postions = new List<SelectListItem>();
            foreach(var s in result)
            {
                SelectListItem test = new SelectListItem(s.ToString(), s.ToString());
                if (!testStr.Contains( s.ToString()))
                {
                    Postions.Add(test);
                    testStr.Add(s.ToString());
                }
                
            }

            return Page();
        }
    }
}
