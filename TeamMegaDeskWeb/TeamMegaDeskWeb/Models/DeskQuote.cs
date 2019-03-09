using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamMegaDeskWeb.Models
{
    public class DeskQuote
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Required, StringLength(50)]
        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [Required]
        public DateTime QuoteDate { get; set; }
        [Range(24, 96),Required]
        public int Width { get; set; }
        [Range(12, 48), Required]
        public int Depth { get; set; }
        [Range(0, 7), Required]
        public int Drawers { get; set; }
        public string Material { get; set; }
        [Display(Name = "Days")]
        [Required]
        public int RushDays { get; set; }
        [Display(Name = "Total")]
        [Required]
        public decimal QuoteAmount { get; set; }
    }
}
