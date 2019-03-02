using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeamMegaDeskWeb.Models
{
    public class TeamMegaDeskWebContext : DbContext
    {
        public TeamMegaDeskWebContext (DbContextOptions<TeamMegaDeskWebContext> options)
            : base(options)
        {
        }

        public DbSet<TeamMegaDeskWeb.Models.DeskQuote> DeskQuote { get; set; }
    }
}
