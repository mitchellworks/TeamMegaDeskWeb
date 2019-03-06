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

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<DeskQuote> DeskQuote { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<DeskQuote> quotes = from m in _context.DeskQuote
                                           select m;

            switch (sortOrder)
            {
                case "name_desc":
                    quotes = quotes.OrderByDescending(s => s.CustomerName);
                    break;
                case "Date":
                    quotes = quotes.OrderBy(s => s.QuoteDate);
                    break;
                case "date_desc":
                    quotes = quotes.OrderByDescending(s => s.QuoteDate);
                    break;
                default:
                    quotes = quotes.OrderBy(s => s.CustomerName);
                    break;
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                quotes = quotes.Where(s => s.CustomerName.Contains(SearchString));
            }
            DeskQuote = await quotes.AsNoTracking().ToListAsync();
        }
    }
}
