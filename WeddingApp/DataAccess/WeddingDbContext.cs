using Microsoft.EntityFrameworkCore;
using WeddingAppDatabase.Entities;

namespace WeddingApp.DataAccess
{
    public class WeddingDbContext : DbContext
    {
        public WeddingDbContext()
        {

        }

        public WeddingDbContext(DbContextOptions<WeddingDbContext> options) : base(options) { }

        //add all tables
        public DbSet<Guests> Guests { get; set; }

        public DbSet<Tables> Tables { get; set; }

        public DbSet<DietaryNeeds> DietaryNeeds { get; set; }

        public DbSet<SeatingChart> SeatingChart { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relationships
            modelBuilder.Entity<Guests>()
                .HasOne(g => g.Guest)
                .WithOne(i => i.GuestsList)
                .HasForeignKey<Guests>(g => g.PlusOneId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<DietaryNeeds>()
                .HasOne(d => d.Guest)
                .WithOne(g => g.DietaryNeed)
                .HasForeignKey<DietaryNeeds>(d => d.GuestId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<SeatingChart>()
                .HasOne(s => s.Table)
                .WithMany(t => t.SeatingCharts)
                .HasForeignKey(s => s.TableId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeatingChart>()
                .HasOne(s => s.Guest)
                .WithMany(g => g.SeatingCharts)
                .HasForeignKey(s => s.GuestId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
