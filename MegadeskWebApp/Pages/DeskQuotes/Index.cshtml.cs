using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegadeskWebApp.Data;
using MegadeskWebApp.Models;

namespace MegadeskWebApp.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegadeskWebApp.Data.MegadeskWebAppContext _context;

        public IndexModel(MegadeskWebApp.Data.MegadeskWebAppContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string CustomerSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }

        public string NextFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync(string sortOrder, string SearchString)
        {
          
            DeskQuote = await _context.DeskQuote.ToListAsync();
            CustomerSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            CurrentFilter = SearchString;
  
            IQueryable<DeskQuote> quote = from s in _context.DeskQuote
                                                select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                quote = quote.Where(s => s.FullName.Contains(SearchString));
            }
           

            switch (sortOrder)
            {
                case "name_desc":
                    quote = quote.OrderByDescending(s => s.FullName);
                    break;
                case "Date":
                    quote = quote.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    quote = quote.OrderByDescending(s => s.Date);
                    break;
                default:
                    quote = quote.OrderBy(s => s.FullName);
                    break;
            }
            DeskQuote = await quote.AsNoTracking().ToListAsync();

        }
    }
}
