using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public void OnGet()
        {
        }
    }
}
