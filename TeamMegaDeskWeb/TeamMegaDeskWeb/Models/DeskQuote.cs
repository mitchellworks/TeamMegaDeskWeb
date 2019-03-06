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
        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime QuoteDate { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Drawers { get; set; }
        public string Material { get; set; }
        [Display(Name = "Days")]
        public int RushDays { get; set; }
        [Display(Name = "Total")]
        public decimal QuoteAmount { get; set; }
    }
}
