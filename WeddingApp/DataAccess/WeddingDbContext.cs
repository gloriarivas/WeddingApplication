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

        public DbSet<Pictures> Pictures { get; set; }

        public DbSet<Restaurants> Restaurants { get; set; }
        
        public DbSet<Bars> Bars { get; set; }

        public DbSet<DressCode> DressCode { get; set; }

        public DbSet<PackingList> PackingList { get; set; }

        public DbSet<WeddingParty> WeddingParties { get; set; }

        public DbSet<PlusOnes> PlusOnes { get; set; }

        public DbSet<EventSpaces> EventSpaces { get; set; }

        public DbSet<EventTypes> EventTypes { get; set; }

        public DbSet<EventSpaceTypes> EventSpaceTypes { get; set; }


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
                
            modelBuilder.Entity<EventSpaceTypes>()
                .HasOne(e => e.EventType)
                .WithMany(t => t.EventSpaceTypes)
                .HasForeignKey(e => e.TypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventSpaceTypes>()
                .HasOne(e => e.EventSpace)
                .WithMany(t => t.EventSpaceTypes)
                .HasForeignKey(e => e.SpaceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pictures>().HasData(
                new Pictures() { PictureId = 1, Url = "Images\\IMG_0629.JPG"},
                new Pictures() { PictureId = 2, Url = "Images\\IMG_0630.JPG"},
                new Pictures() { PictureId = 3, Url = "Images\\IMG_1540.JPG"},
                new Pictures() { PictureId = 4, Url = "Images\\IMG_2702.JPG"},
                new Pictures() { PictureId = 5, Url = "Images\\IMG_2708.JPG"},
                new Pictures() { PictureId = 6, Url = "Images\\IMG_2714.JPG"},
                new Pictures() { PictureId = 7, Url = "Images\\IMG_3218.JPG"},
                new Pictures() { PictureId = 8, Url = "Images\\IMG_3271.JPG"},
                new Pictures() { PictureId = 9, Url = "Images\\IMG_3285.JPG"},
                new Pictures() { PictureId = 10, Url = "Images\\IMG_3291.JPG"},
                new Pictures() { PictureId = 11, Url = "Images\\IMG_3309.JPG"},
                new Pictures() { PictureId = 12, Url = "Images\\IMG_4107.JPG"},
                new Pictures() { PictureId = 13, Url = "Images\\IMG_4370.JPG"},
                new Pictures() { PictureId = 14, Url = "Images\\IMG_4390.JPG"},
                new Pictures() { PictureId = 15, Url = "Images\\OXLZ6554.JPG"},
                new Pictures() { PictureId = 16, Url = "Images\\SIAM0204.JPG"}
                );

            modelBuilder.Entity<EventTypes>().HasData(

                new EventTypes() { EventTypeId = 100, TypeName = "Ceremony" },
                new EventTypes() { EventTypeId = 101, TypeName = "Cocktail" },
                new EventTypes() { EventTypeId = 102, TypeName = "Reception" }
                );
        }

        

    }
}
