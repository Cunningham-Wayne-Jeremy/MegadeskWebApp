﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegadeskWebApp.Data;
using MegadeskWebApp.Models;

namespace MegadeskWebApp.Pages.DeskQuotes
{
    public class EditModel : PageModel
    {
        public enum surface { Oak = 200, Laminate = 100, Pine = 50, Rosewood = 300, Veneer = 125 };
        private readonly MegadeskWebApp.Data.MegadeskWebAppContext _context;

        public EditModel(MegadeskWebApp.Data.MegadeskWebAppContext context)
        {
            _context = context;
        }

        public SelectList Materials { get; set; }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Materials = new SelectList(Enum.GetNames(typeof(CreateModel.surface)));

            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote.FirstOrDefaultAsync(m => m.ID == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeskQuote).State = EntityState.Modified;

            try
            {
                DeskQuote.Total = calculateQuote();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuote.Any(e => e.ID == id);
        }

        public decimal calculateQuote()
        {

            decimal rushcost = 0;

            if (DeskQuote.Width * DeskQuote.Depth < 1000)
            {
                switch (DeskQuote.RushDays)
                {
                    case 3:
                        rushcost = 60;
                        break;
                    case 5:
                        rushcost = 40;
                        break;
                    case 7:
                        rushcost = 30;
                        break;
                    default:
                        break;
                }
            }
            else if (DeskQuote.Width * DeskQuote.Depth >= 1000 && DeskQuote.Width * DeskQuote.Depth <= 2000)
            {
                switch (DeskQuote.RushDays)
                {
                    case 3:
                        rushcost = 70;
                        break;
                    case 5:
                        rushcost = 50;
                        break;
                    case 7:
                        rushcost = 35;
                        break;
                    default:
                        break;
                }
            }
            else if (DeskQuote.Width * DeskQuote.Depth > 2000)
            {
                switch (DeskQuote.RushDays)
                {
                    case 3:
                        rushcost = 80;
                        break;
                    case 5:
                        rushcost = 60;
                        break;
                    case 7:
                        rushcost = 45;
                        break;
                    default:
                        break;
                }
            }

            decimal baseprice = 0;

            if (DeskQuote.Width * DeskQuote.Depth > 1000)
            {
                baseprice = 200 + DeskQuote.Width * DeskQuote.Depth;
            }
            else
            {
                baseprice = 200;
            }

            surface materialcost = ((surface)Enum.Parse(typeof(surface), DeskQuote.SurfaceMaterial));
            decimal total = (baseprice + DeskQuote.NumDrawers * 50 + (decimal)materialcost + rushcost);
            return total;
        }
    }
}
