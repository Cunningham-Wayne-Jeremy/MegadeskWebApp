using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegadeskWebApp.Data;
using MegadeskWebApp.Models;

namespace MegadeskWebApp.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        public enum surface { Oak = 200, Laminate = 100, Pine = 50, Rosewood = 300, Veneer = 125 };
        private readonly MegadeskWebApp.Data.MegadeskWebAppContext _context;

        public CreateModel(MegadeskWebApp.Data.MegadeskWebAppContext context)
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
            surface materialcost = ((surface)Enum.Parse(typeof(surface), DeskQuote.SurfaceMaterial));
            decimal rushcost = 0;

        DeskQuote.Total = ((200 + DeskQuote.Width * DeskQuote.Depth) + DeskQuote.NumDrawers * 50 + (decimal)materialcost + rushcost);
            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}