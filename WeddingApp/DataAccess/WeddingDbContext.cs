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

        public DbSet<Checklists> Checklists { get; set; }

        public DbSet<Dates> Dates { get; set; }

        public DbSet<GalleryImages> GalleryImages { get; set; }

        public DbSet<Restaurants> Restaurants { get; set; }
        
        public DbSet<Bars> Bars { get; set; }

        public DbSet<DressCode> DressCode { get; set; }

        public DbSet<PackingList> PackingList { get; set; }

        public DbSet<WeddingParty> WeddingParties { get; set; }

        public DbSet<PlusOnes> PlusOnes { get; set; }

        public DbSet<EventSpaces> EventSpaces { get; set; }

        public DbSet<EventTypes> EventTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relationships
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

            modelBuilder.Entity<Restaurants>()
                .HasOne(d => d.DressCode)
                .WithMany(r => r.Restaurants)
                .HasForeignKey(d => d.DressCodeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Guests>()
                .HasOne(g => g.WeddingParty)
                .WithMany(w => w.Guests)
                .HasForeignKey(g => g.WeddingPartyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlusOnes>()
                .HasOne(p => p.PlusOne)
                .WithMany(g => g.PlusOnes)
                .HasForeignKey(p => p.PlusOneId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlusOnes>()
                .HasOne(p => p.InvitedGuest)
                .WithMany(g => g.InvitedGuests)
                .HasForeignKey(p => p.InvitedGuestId)
                .OnDelete(DeleteBehavior.NoAction);
                
            modelBuilder.Entity<EventSpaces>()
                .HasOne(e => e.EventType)
                .WithMany(t => t.EventSpaces)
                .HasForeignKey(e => e.EventTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventTypes>().HasData(

                new EventTypes() { EventTypeId = 100, TypeName = "Ceremony" },
                new EventTypes() { EventTypeId = 101, TypeName = "Cocktail" },
                new EventTypes() { EventTypeId = 102, TypeName = "Reception" }
                );
        }

        

    }
}
