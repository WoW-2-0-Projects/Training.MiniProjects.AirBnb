﻿// <auto-generated />
using System;
using AirBnb.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AirBnb.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AirBnb.Domain.Entities.ListingCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ImageStorageFileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.ToTable("ListingCategory");
                });

            modelBuilder.Entity("AirBnb.Domain.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Locations", (string)null);

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AirBnb.Domain.Entities.StorageFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("StorageFiles");
                });

            modelBuilder.Entity("AirBnb.Domain.Entities.City", b =>
                {
                    b.HasBaseType("AirBnb.Domain.Entities.Location");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.HasIndex("ParentId");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("AirBnb.Domain.Entities.Country", b =>
                {
                    b.HasBaseType("AirBnb.Domain.Entities.Location");

                    b.Property<string>("Code")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("AirBnb.Domain.Entities.ListingCategory", b =>
                {
                    b.HasOne("AirBnb.Domain.Entities.StorageFile", "ImageStorageFile")
                        .WithOne()
                        .HasForeignKey("AirBnb.Domain.Entities.ListingCategory", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageStorageFile");
                });

            modelBuilder.Entity("AirBnb.Domain.Entities.City", b =>
                {
                    b.HasOne("AirBnb.Domain.Entities.Country", null)
                        .WithMany("Cities")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("AirBnb.Domain.Entities.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
