﻿// <auto-generated />
using System;
using Bloggy.REPO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bloggy.REPO.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240123183830_Initial2")]
    partial class Initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bloggy.CORE.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ac varius augue. Phasellus molestie felis at ex aliquet mollis. Aliquam consectetur leo sit amet eros malesuada, vel elementum ante feugiat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Curabitur fringilla dui nec tincidunt consequat. Proin eros.",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 1, 23, 21, 38, 30, 97, DateTimeKind.Local).AddTicks(2095),
                            GenreId = new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                            ImageId = new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"),
                            IsDeleted = false,
                            Title = "Deneme",
                            ViewCount = 15
                        });
                });

            modelBuilder.Entity("Bloggy.CORE.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("15fd39a8-a3fc-46a1-b40b-5ae6825b4c5a"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 1, 23, 21, 38, 30, 97, DateTimeKind.Local).AddTicks(2451),
                            IsDeleted = false,
                            Name = "ASP.Net Core"
                        });
                });

            modelBuilder.Entity("Bloggy.CORE.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5aa0376e-d526-4fa5-8d48-5dda2d9cb585"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 1, 23, 21, 38, 30, 97, DateTimeKind.Local).AddTicks(2593),
                            FileName = "images/testimage",
                            FileType = "jpg",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Bloggy.CORE.Entities.Article", b =>
                {
                    b.HasOne("Bloggy.CORE.Entities.Genre", "Genre")
                        .WithMany("Articles")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bloggy.CORE.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Bloggy.CORE.Entities.Genre", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Bloggy.CORE.Entities.Image", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}