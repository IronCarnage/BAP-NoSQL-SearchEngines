using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BAP_NoSQL_SearchEngines.Models
{
    public partial class BAPContext : DbContext
    {
        public BAPContext()
            : base("name=BAPContext")
        {
        }

        public virtual DbSet<Articles> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>()
                .Property(e => e.BasePrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Articles>()
                .Property(e => e.BaseNettoPrice)
                .HasPrecision(18, 3);
        }
    }
}
