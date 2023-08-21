﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicLibrary.Data.Context;

#nullable disable

namespace MusicLibrary.Data.Migrations
{
    [DbContext(typeof(MusicLibraryDbContext))]
    [Migration("20230820030215_ModelSeed")]
    partial class ModelSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MusicLibrary.Core.Models.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("created_at");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("genre_id");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("BIT")
                        .HasColumnName("is_disabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("artist", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1895edf2-3432-4c67-928a-7eab36770e78"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            GenreId = new Guid("a6513541-e32d-4e9b-a657-8be9cee6aeb5"),
                            IsDisabled = false,
                            Name = "Daft Punk"
                        },
                        new
                        {
                            Id = new Guid("90c847a3-9d97-46eb-a8a1-50985c262dc7"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            GenreId = new Guid("65f97fdf-c941-42b7-84b6-d72cad67e150"),
                            IsDisabled = false,
                            Name = "Metallica"
                        });
                });

            modelBuilder.Entity("MusicLibrary.Core.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("BIT")
                        .HasColumnName("is_disabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("genre", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6513541-e32d-4e9b-a657-8be9cee6aeb5"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Name = "Eletronic"
                        },
                        new
                        {
                            Id = new Guid("65f97fdf-c941-42b7-84b6-d72cad67e150"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Name = "Thrash Metal"
                        });
                });

            modelBuilder.Entity("MusicLibrary.Core.Models.Production", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("id");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("artist_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("BIT")
                        .HasColumnName("is_disabled");

                    b.Property<byte>("ProductionType")
                        .HasColumnType("TINYINT")
                        .HasColumnName("production_type");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("TINYINT")
                        .HasColumnName("release_year");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("production", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("47e4541d-7530-4387-9723-4a40b3c8afcf"),
                            ArtistId = new Guid("1895edf2-3432-4c67-928a-7eab36770e78"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            ProductionType = (byte)3,
                            ReleaseDate = "1995-05-08",
                            Title = "Da Funk"
                        },
                        new
                        {
                            Id = new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"),
                            ArtistId = new Guid("90c847a3-9d97-46eb-a8a1-50985c262dc7"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            ProductionType = (byte)1,
                            ReleaseDate = "1984-07-27",
                            Title = "Ride the Lightning"
                        });
                });

            modelBuilder.Entity("MusicLibrary.Core.Models.Track", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("BIT")
                        .HasColumnName("is_disabled");

                    b.Property<float>("Length")
                        .HasColumnType("TINYINT")
                        .HasColumnName("length");

                    b.Property<byte>("Position")
                        .HasColumnType("TINYINT")
                        .HasColumnName("position");

                    b.Property<Guid>("ProductionId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("production_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ProductionId");

                    b.ToTable("track", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9054c37d-e8f9-4c4e-9a02-839b57b87adb"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Length = 3.49f,
                            Position = (byte)1,
                            ProductionId = new Guid("47e4541d-7530-4387-9723-4a40b3c8afcf"),
                            Title = "Da Funk - Radio Edit"
                        },
                        new
                        {
                            Id = new Guid("36cbd79a-cabc-4305-bdba-4eca798f28d9"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Length = 6.53f,
                            Position = (byte)2,
                            ProductionId = new Guid("47e4541d-7530-4387-9723-4a40b3c8afcf"),
                            Title = "Musique"
                        },
                        new
                        {
                            Id = new Guid("d1b657eb-8dcb-4b58-baba-8e4389b0f7be"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Length = 5.34f,
                            Position = (byte)3,
                            ProductionId = new Guid("47e4541d-7530-4387-9723-4a40b3c8afcf"),
                            Title = "Da Funk"
                        },
                        new
                        {
                            Id = new Guid("1bb2dba9-98d4-441e-9cd4-6118499e2b31"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Length = 4.44f,
                            Position = (byte)1,
                            ProductionId = new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"),
                            Title = "Fight Fire With Fire"
                        },
                        new
                        {
                            Id = new Guid("e342c786-0bb6-472e-bd2e-c2a1ed52cd86"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Length = 6.36f,
                            Position = (byte)0,
                            ProductionId = new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"),
                            Title = "Ride The Lightning"
                        },
                        new
                        {
                            Id = new Guid("a9595279-6607-4f15-b944-bd412a592329"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Length = 5.09f,
                            Position = (byte)3,
                            ProductionId = new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"),
                            Title = "For Whom The Bell Tolls"
                        },
                        new
                        {
                            Id = new Guid("4b891bc1-cad7-4b78-8178-7f155bbff40d"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Length = 6.57f,
                            Position = (byte)4,
                            ProductionId = new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"),
                            Title = "Fade To Black"
                        },
                        new
                        {
                            Id = new Guid("3292b0df-e7dd-4704-b8d0-587e3ae42ef3"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Length = 4.04f,
                            Position = (byte)5,
                            ProductionId = new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"),
                            Title = "Trapped Under Ice"
                        },
                        new
                        {
                            Id = new Guid("49c8b089-0d68-44fe-8ee3-ba0de40230e8"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Length = 4.23f,
                            Position = (byte)6,
                            ProductionId = new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"),
                            Title = "Escape"
                        },
                        new
                        {
                            Id = new Guid("c7e416f4-e84d-4696-ab1e-261f550b28f2"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Length = 6.36f,
                            Position = (byte)7,
                            ProductionId = new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"),
                            Title = "Creeping Death"
                        },
                        new
                        {
                            Id = new Guid("2b59716b-ffde-4212-adad-b7f4949db2ee"),
                            CreatedAt = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            IsDisabled = false,
                            Length = 8.53f,
                            Position = (byte)8,
                            ProductionId = new Guid("b2de8c77-30d2-405e-a3fd-2acb2e4120ea"),
                            Title = "The Call Of Ktulu"
                        });
                });

            modelBuilder.Entity("MusicLibrary.Core.Models.Artist", b =>
                {
                    b.HasOne("MusicLibrary.Core.Models.Genre", "Genre")
                        .WithMany("Artists")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MusicLibrary.Core.Models.Production", b =>
                {
                    b.HasOne("MusicLibrary.Core.Models.Artist", "Artist")
                        .WithMany("Productions")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicLibrary.Core.Models.Track", b =>
                {
                    b.HasOne("MusicLibrary.Core.Models.Production", "Production")
                        .WithMany("Tracks")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Production");
                });

            modelBuilder.Entity("MusicLibrary.Core.Models.Artist", b =>
                {
                    b.Navigation("Productions");
                });

            modelBuilder.Entity("MusicLibrary.Core.Models.Genre", b =>
                {
                    b.Navigation("Artists");
                });

            modelBuilder.Entity("MusicLibrary.Core.Models.Production", b =>
                {
                    b.Navigation("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}