using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cbDevPGAtools.Models;

namespace cbDevPGAtools.Data
{
    public class cbDevPGAtoolsDbContext: DbContext
    {
        public DbSet<DKtourney> DKT { get; set; }

        public DbSet<Golfer> GOLFER { get; set; }


        public cbDevPGAtoolsDbContext(DbContextOptions<cbDevPGAtoolsDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

    }
}
