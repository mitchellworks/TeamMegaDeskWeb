using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamMegaDeskWeb.Models;
using System.Web;

namespace TeamMegaDeskWeb.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly TeamMegaDeskWeb.Models.TeamMegaDeskWebContext _context;

        public CreateModel(TeamMegaDeskWeb.Models.TeamMegaDeskWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            QuoteMath math1 = new QuoteMath();
            DeskQuote.QuoteAmount = math1.DeskQuote1(DeskQuote.CustomerName, DeskQuote.Width, DeskQuote.Depth, DeskQuote.Drawers, DeskQuote.Material, DeskQuote.RushDays);
            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            
            

        }

        
    }

        
}