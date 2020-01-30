using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class BewerberDbContext : DbContext
    {
        public DbSet<Bewerber> BewerberSet { get; set; }
        public DbSet<Ausschreibung> AusschreibungSet { get; set; }
        public DbSet<Adresse> AdresseSet { get; set; }

        public DbSet<AusschreibungBewerber> AusschreibungBewerberSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Server=.\SQLExpress;Database=BewerberDb;Trusted_Connection=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AusschreibungBewerber>().HasOne<Bewerber>(x => x.Bewerber).WithMany(y => y.AusschreibungenBewerber).HasForeignKey(x => x.BewerberId);

            modelBuilder.Entity<AusschreibungBewerber>().HasOne<Ausschreibung>(x => x.Ausschreibung).WithMany(y => y.AusschreibungenBewerber).HasForeignKey(x => x.AusschreibungId);

            modelBuilder.Entity<Bewerber>().Property<DateTime>("LastUpdated").HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Bewerber>().Property<Guid>("LastGuid").HasDefaultValue(Guid.NewGuid()).ValueGeneratedOnAdd();

            modelBuilder.Entity<Bewerber>().Property(x => x.FullName).HasComputedColumnSql("[Vorname] + ', ' + [Nachname]");
        }
    }
}
