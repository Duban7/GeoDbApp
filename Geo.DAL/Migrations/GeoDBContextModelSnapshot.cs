﻿// <auto-generated />
using System;
using Geo.DAL.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Geo.DAL.Migrations
{
    [DbContext(typeof(GeoDBContext))]
    partial class GeoDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExpeditionGeologist", b =>
                {
                    b.Property<int>("ExpeditionsId")
                        .HasColumnType("int");

                    b.Property<int>("GeologistsId")
                        .HasColumnType("int");

                    b.HasKey("ExpeditionsId", "GeologistsId");

                    b.HasIndex("GeologistsId");

                    b.ToTable("ExpeditionGeologist");
                });

            modelBuilder.Entity("Geo.Domain.Models.Expedition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RouteID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RouteID");

                    b.ToTable("Expeditions");
                });

            modelBuilder.Entity("Geo.Domain.Models.Geologist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Geologists");
                });

            modelBuilder.Entity("Geo.Domain.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("Geo.Domain.Models.PlannedExpedition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RouteID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RouteID");

                    b.ToTable("PlannedExpeditions");
                });

            modelBuilder.Entity("Geo.Domain.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Geo.Domain.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EndPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartPoint")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("MapRoute", b =>
                {
                    b.Property<int>("MapsId")
                        .HasColumnType("int");

                    b.Property<int>("RoutesId")
                        .HasColumnType("int");

                    b.HasKey("MapsId", "RoutesId");

                    b.HasIndex("RoutesId");

                    b.ToTable("MapRoute");
                });

            modelBuilder.Entity("RegionRoute", b =>
                {
                    b.Property<int>("RegionsId")
                        .HasColumnType("int");

                    b.Property<int>("RoutesId")
                        .HasColumnType("int");

                    b.HasKey("RegionsId", "RoutesId");

                    b.HasIndex("RoutesId");

                    b.ToTable("RegionRoute");
                });

            modelBuilder.Entity("ExpeditionGeologist", b =>
                {
                    b.HasOne("Geo.Domain.Models.Expedition", null)
                        .WithMany()
                        .HasForeignKey("ExpeditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geo.Domain.Models.Geologist", null)
                        .WithMany()
                        .HasForeignKey("GeologistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Geo.Domain.Models.Expedition", b =>
                {
                    b.HasOne("Geo.Domain.Models.Route", "Route")
                        .WithMany("Expeditions")
                        .HasForeignKey("RouteID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Geo.Domain.Models.Map", b =>
                {
                    b.HasOne("Geo.Domain.Models.Region", "Region")
                        .WithMany("Maps")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Geo.Domain.Models.PlannedExpedition", b =>
                {
                    b.HasOne("Geo.Domain.Models.Route", "Route")
                        .WithMany("PlannedExpeditions")
                        .HasForeignKey("RouteID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("MapRoute", b =>
                {
                    b.HasOne("Geo.Domain.Models.Map", null)
                        .WithMany()
                        .HasForeignKey("MapsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geo.Domain.Models.Route", null)
                        .WithMany()
                        .HasForeignKey("RoutesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegionRoute", b =>
                {
                    b.HasOne("Geo.Domain.Models.Region", null)
                        .WithMany()
                        .HasForeignKey("RegionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geo.Domain.Models.Route", null)
                        .WithMany()
                        .HasForeignKey("RoutesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Geo.Domain.Models.Region", b =>
                {
                    b.Navigation("Maps");
                });

            modelBuilder.Entity("Geo.Domain.Models.Route", b =>
                {
                    b.Navigation("Expeditions");

                    b.Navigation("PlannedExpeditions");
                });
#pragma warning restore 612, 618
        }
    }
}
