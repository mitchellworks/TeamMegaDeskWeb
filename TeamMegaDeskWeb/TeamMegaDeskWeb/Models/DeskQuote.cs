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
        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Drawers { get; set; }
        public string Material { get; set; }
        public int RushDays { get; set; }
        public decimal QuoteAmount { get; set; }
    }
}
