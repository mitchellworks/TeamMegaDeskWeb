using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamMegaDeskWeb.Models;

namespace TeamMegaDeskWeb.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly TeamMegaDeskWeb.Models.TeamMegaDeskWebContext _context;

        public IndexModel(TeamMegaDeskWeb.Models.TeamMegaDeskWebContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var quotes = from m in _context.DeskQuote
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                quotes = quotes.Where(s => s.CustomerName.Contains(SearchString));
            }
            DeskQuote = await quotes.ToListAsync();
        }
    }
}
