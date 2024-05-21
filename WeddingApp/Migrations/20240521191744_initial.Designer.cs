﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeddingApp.DataAccess;

#nullable disable

namespace WeddingApp.Migrations
{
    [DbContext(typeof(WeddingDbContext))]
    [Migration("20240521191744_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<int>("PlusOneId")
                        .HasColumnType("int");

                    b.HasKey("GuestId");

                    b.HasIndex("PlusOneId")
                        .IsUnique();

                    b.ToTable("Guests");
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

            modelBuilder.Entity("WeddingAppDatabase.Entities.DietaryNeeds", b =>
                {
                    b.HasOne("WeddingAppDatabase.Entities.Guests", "Guest")
                        .WithOne("DietaryNeed")
                        .HasForeignKey("WeddingAppDatabase.Entities.DietaryNeeds", "GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Guests", b =>
                {
                    b.HasOne("WeddingAppDatabase.Entities.Guests", "Guest")
                        .WithOne("GuestsList")
                        .HasForeignKey("WeddingAppDatabase.Entities.Guests", "PlusOneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");
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

            modelBuilder.Entity("WeddingAppDatabase.Entities.Guests", b =>
                {
                    b.Navigation("DietaryNeed");

                    b.Navigation("GuestsList");

                    b.Navigation("SeatingCharts");
                });

            modelBuilder.Entity("WeddingAppDatabase.Entities.Tables", b =>
                {
                    b.Navigation("SeatingCharts");
                });
#pragma warning restore 612, 618
        }
    }
}
