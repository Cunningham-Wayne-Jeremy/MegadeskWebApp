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

        [Display(Name = "Customer Name")]
        [RegularExpression(@"^[A-Z ]+[a-zA-Z ]*$")]
        [Required]
        [StringLength(30)]
        public string FullName { get; set; }

        [Display(Name = "Number of Drawers")]
        [Range(0, 7)]
        public int NumDrawers { get; set; }

        [Range(24, 96)]
        public int Width { get; set; }

        [Range(12, 48)]
        public int Depth { get; set; }

        [Display(Name = "Surface Material")]
        public string SurfaceMaterial { get; set; }

        [Display(Name = "Rush Days")]
        [RegularExpression(@"(3|5|7|14)")]
        public decimal RushDays { get; set; }
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public decimal Total { get; set; }
    }
}
