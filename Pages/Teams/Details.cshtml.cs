using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace League.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        //Atribute
        private readonly LeagueContext _leagueDB;

        //Propeties
        [BindProperty(SupportsGet =true)]
        public string Team {  get; set; }

        //Constructor
        public DetailsModel(LeagueContext leagueDB)
        {
            _leagueDB = leagueDB;
        }

        //Page methods
        public void OnGet()
        {
            Debug.WriteLine(this.Team);
        }
    }
}
