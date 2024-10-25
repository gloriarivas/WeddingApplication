﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeddingApp.DataAccess;

#nullable disable

namespace WeddingApp.Migrations
{
    [DbContext(typeof(WeddingDbContext))]
    partial class WeddingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeddingAppDatabase.Entities.Bars", b =>
                {
                    b.Property<int>("BarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BarId"));

                    b.Property<string>("BarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoursEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoursStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialInstructions")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BarId");

                    b.ToTable("Bars");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Checklists", b =>
                {
                    b.Property<int>("ChecklistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChecklistId"));

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("ListItem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChecklistId");

                    b.ToTable("Checklists");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Dates", b =>
                {
                    b.Property<int>("DateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DateId"));

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DateId");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.DietaryNeeds", b =>
                {
                    b.Property<int>("DietNeedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DietNeedId"));

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<string>("Restrictions")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DietNeedId");

                    b.HasIndex("GuestId")
                        .IsUnique();

                    b.ToTable("DietaryNeeds");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.DressCode", b =>
                {
                    b.Property<int>("DressCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DressCodeId"));

                    b.Property<string>("BannedItemsMen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BannedItemsWomen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionMen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionWomen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DressCodeId");

                    b.ToTable("DressCode");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.EventSpaces", b =>
                {
                    b.Property<int>("EventSpaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventSpaceId"));

                    b.Property<double?>("BookingFee")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventSpaceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("MaxGuests")
                        .HasColumnType("int");

                    b.Property<int?>("MinGuests")
                        .HasColumnType("int");

                    b.HasKey("EventSpaceId");

                    b.HasIndex("EventTypeId");

                    b.ToTable("EventSpaces");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.EventTypes", b =>
                {
                    b.Property<int>("EventTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventTypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventTypeId");

                    b.ToTable("EventTypes");

                    b.HasData(
                        new
                        {
                            EventTypeId = 100,
                            TypeName = "Ceremony"
                        },
                        new
                        {
                            EventTypeId = 101,
                            TypeName = "Cocktail"
                        },
                        new
                        {
                            EventTypeId = 102,
                            TypeName = "Reception"
                        });
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Guests", b =>
                {
                    b.Property<int>("GuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuestId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WeddingPartyId")
                        .HasColumnType("int");

                    b.HasKey("GuestId");

                    b.HasIndex("WeddingPartyId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.PackingList", b =>
                {
                    b.Property<int>("PackingListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackingListId"));

                    b.Property<bool>("IsPacked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPurchased")
                        .HasColumnType("bit");

                    b.Property<string>("ListItem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PackingListId");

                    b.ToTable("PackingList");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Pictures", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PictureId"));

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PictureId");

                    b.ToTable("Pictures");

                    b.HasData(
                        new
                        {
                            PictureId = 1,
                            Url = "Images\\IMG_0629.JPG"
                        },
                        new
                        {
                            PictureId = 2,
                            Url = "Images\\IMG_0630.JPG"
                        },
                        new
                        {
                            PictureId = 3,
                            Url = "Images\\IMG_1540.JPG"
                        },
                        new
                        {
                            PictureId = 4,
                            Url = "Images\\IMG_2702.JPG"
                        },
                        new
                        {
                            PictureId = 5,
                            Url = "Images\\IMG_2708.JPG"
                        },
                        new
                        {
                            PictureId = 6,
                            Url = "Images\\IMG_2714.JPG"
                        },
                        new
                        {
                            PictureId = 7,
                            Url = "Images\\IMG_3218.JPG"
                        },
                        new
                        {
                            PictureId = 8,
                            Url = "Images\\IMG_3271.JPG"
                        },
                        new
                        {
                            PictureId = 9,
                            Url = "Images\\IMG_3285.JPG"
                        },
                        new
                        {
                            PictureId = 10,
                            Url = "Images\\IMG_3291.JPG"
                        },
                        new
                        {
                            PictureId = 11,
                            Url = "Images\\IMG_3309.JPG"
                        },
                        new
                        {
                            PictureId = 12,
                            Url = "Images\\IMG_4107.JPG"
                        },
                        new
                        {
                            PictureId = 13,
                            Url = "Images\\IMG_4370.JPG"
                        },
                        new
                        {
                            PictureId = 14,
                            Url = "Images\\IMG_4390.JPG"
                        },
                        new
                        {
                            PictureId = 15,
                            Url = "Images\\OXLZ6554.JPG"
                        },
                        new
                        {
                            PictureId = 16,
                            Url = "Images\\SIAM0204.JPG"
                        });
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.PlusOnes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("InvitedGuestId")
                        .HasColumnType("int");

                    b.Property<int?>("PlusOneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvitedGuestId");

                    b.HasIndex("PlusOneId");

                    b.ToTable("PlusOnes");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Restaurants", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("CuisineType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DressCodeId")
                        .HasColumnType("int");

                    b.Property<string>("HoursBreakfastEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoursBreakfastStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoursDinnerEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoursDinnerStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoursLunchEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoursLunchStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.HasIndex("DressCodeId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.SeatingChart", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"));

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<decimal>("XCoord")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("YCoord")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SeatId");

                    b.HasIndex("GuestId");

                    b.HasIndex("TableId");

                    b.ToTable("SeatingChart");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Tables", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TableId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.WeddingParty", b =>
                {
                    b.Property<int>("PartyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartyId"));

                    b.Property<bool>("InWeddingParty")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PartyId");

                    b.ToTable("WeddingParties");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.DietaryNeeds", b =>
                {
                    b.HasOne("WeddingAppDatabase.Entities.Guests", "Guest")
                        .WithOne("DietaryNeed")
                        .HasForeignKey("WeddingAppDatabase.Entities.DietaryNeeds", "GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.EventSpaces", b =>
                {
                    b.HasOne("WeddingAppDatabase.Entities.EventTypes", "EventType")
                        .WithMany("EventSpaces")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Guests", b =>
                {
                    b.HasOne("WeddingAppDatabase.Entities.WeddingParty", "WeddingParty")
                        .WithMany("Guests")
                        .HasForeignKey("WeddingPartyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("WeddingParty");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.PlusOnes", b =>
                {
                    b.HasOne("WeddingAppDatabase.Entities.Guests", "InvitedGuest")
                        .WithMany("InvitedGuests")
                        .HasForeignKey("InvitedGuestId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WeddingAppDatabase.Entities.Guests", "PlusOne")
                        .WithMany("PlusOnes")
                        .HasForeignKey("PlusOneId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("InvitedGuest");

                    b.Navigation("PlusOne");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Restaurants", b =>
                {
                    b.HasOne("WeddingAppDatabase.Entities.DressCode", "DressCode")
                        .WithMany("Restaurants")
                        .HasForeignKey("DressCodeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("DressCode");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.SeatingChart", b =>
                {
                    b.HasOne("WeddingAppDatabase.Entities.Guests", "Guest")
                        .WithMany("SeatingCharts")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeddingAppDatabase.Entities.Tables", "Table")
                        .WithMany("SeatingCharts")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.DressCode", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.EventTypes", b =>
                {
                    b.Navigation("EventSpaces");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Guests", b =>
                {
                    b.Navigation("DietaryNeed");

                    b.Navigation("InvitedGuests");

                    b.Navigation("PlusOnes");

                    b.Navigation("SeatingCharts");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Tables", b =>
                {
                    b.Navigation("SeatingCharts");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.WeddingParty", b =>
                {
                    b.Navigation("Guests");
                });
#pragma warning restore 612, 618
        }
    }
}
