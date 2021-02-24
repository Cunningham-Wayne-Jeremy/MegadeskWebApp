using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegadeskWebApp.Models;

namespace MegadeskWebApp.Data
{
    public class MegadeskWebAppContext : DbContext
    {
        public MegadeskWebAppContext (DbContextOptions<MegadeskWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<MegadeskWebApp.Models.DeskQuote> DeskQuote { get; set; }
    }
}
