﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCoreClient.ConsoleApp.PostgreSQL;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetCoreClient.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20211211143906_Add1")]
    partial class Add1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("NetCoreClient.Models.AssemblyCatelogEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CatalogName")
                        .HasColumnType("text");

                    b.Property<string>("Href")
                        .HasColumnType("text");

                    b.Property<string>("LocationId")
                        .HasColumnType("text");

                    b.Property<string>("ReleaseId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("ReleaseId");

                    b.ToTable("AssemblyCatelogEntity");
                });

            modelBuilder.Entity("NetCoreClient.Models.LocationEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CountryCode")
                        .HasColumnType("text");

                    b.Property<string>("Href")
                        .HasColumnType("text");

                    b.Property<string>("StateCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LocationEntity");
                });

            modelBuilder.Entity("NetCoreClient.Models.ReleaseEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Href")
                        .HasColumnType("text");

                    b.Property<string>("Period")
                        .HasColumnType("text");

                    b.Property<string>("Year")
                        .HasColumnType("text");

                    b.Property<string>("Year2")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ReleaseEntity");
                });

            modelBuilder.Entity("NetCoreClient.Models.AssemblyCatelogEntity", b =>
                {
                    b.HasOne("NetCoreClient.Models.LocationEntity", "LocationEntity")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("NetCoreClient.Models.ReleaseEntity", "ReleaseEntity")
                        .WithMany()
                        .HasForeignKey("ReleaseId");

                    b.Navigation("LocationEntity");

                    b.Navigation("ReleaseEntity");
                });
#pragma warning restore 612, 618
        }
    }
}