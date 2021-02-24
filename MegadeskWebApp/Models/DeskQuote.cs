using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegadeskWebApp.Models
{
    public class DeskQuote
    {
        public int ID { get; set; }
        public string FullName { get; set; }

        public int NumDrawers { get; set; }

        public int Width { get; set; }

        public int Depth { get; set; }

        public string SurfaceMaterial { get; set; }
        public decimal RushDays { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public decimal Total { get; set; }
    }
}
