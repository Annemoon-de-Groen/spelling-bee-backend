﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api_cinema_challenge.Data;

#nullable disable

namespace api_cinema_challenge.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240328125918_Added_Created_At_Tickets")]
    partial class Added_Created_At_Tickets
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api_cinema_challenge.Models.Play", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer")
                        .HasColumnName("capacity");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.HasKey("Id");

                    b.ToTable("play");
                });

            modelBuilder.Entity("api_cinema_challenge.Models.Players", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("bio");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("Functie")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("functie");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Rol")
                        .HasColumnType("text")
                        .HasColumnName("rol");

                    b.HasKey("Id");

                    b.ToTable("players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Hannelieke speelt al sinds haar vierde toneel. Ze doet zowel musicals als theatervoorstellingen. Idk wat ze nog meer doet dus bla bla bla",
                            FirstName = "Hannelieke",
                            Functie = "acteur, regisseur, vertaler",
                            LastName = "Hoogenboom",
                            Rol = "Rona"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Informatie over Neomi",
                            FirstName = "Neomi",
                            Functie = "acteur",
                            LastName = "Bes",
                            Rol = "Panch"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Informatie over Anne-Sophie",
                            FirstName = "Anne-Sophie",
                            Functie = "acteur, choreograaf",
                            LastName = "",
                            Rol = "Mitch Mahoney"
                        },
                        new
                        {
                            Id = 4,
                            Bio = "Informatie over Diede",
                            FirstName = "Diede",
                            Functie = "acteur",
                            LastName = "",
                            Rol = "Olive Ostrovsky"
                        },
                        new
                        {
                            Id = 5,
                            Bio = "Informatie over Lotte",
                            FirstName = "Lotte",
                            Functie = "acteur",
                            LastName = "Hoek",
                            Rol = "Logainne SchwartzandGrubenierre"
                        },
                        new
                        {
                            Id = 6,
                            Bio = "Informatie over Lara",
                            FirstName = "Lara",
                            Functie = "acteur",
                            LastName = "",
                            Rol = "Marcy Park"
                        },
                        new
                        {
                            Id = 7,
                            Bio = "Informatie over Liza",
                            FirstName = "Liza",
                            Functie = "acteur",
                            LastName = "",
                            Rol = "William Barfée"
                        },
                        new
                        {
                            Id = 8,
                            Bio = "Informatie over Morris",
                            FirstName = "Morris",
                            Functie = "acteur",
                            LastName = "Mooijaart",
                            Rol = "Leaf Coneybear"
                        },
                        new
                        {
                            Id = 9,
                            Bio = "Informatie over Quinten",
                            FirstName = "Quinten",
                            Functie = "acteur",
                            LastName = "van Koeverden",
                            Rol = "Chip Tolentino"
                        });
                });

            modelBuilder.Entity("api_cinema_challenge.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("definition");

                    b.Property<string>("Sentence")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sentence");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("word");

                    b.HasKey("Id");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("api_cinema_challenge.Models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Points")
                        .HasColumnType("integer")
                        .HasColumnName("points");

                    b.HasKey("Id");

                    b.ToTable("score");
                });

            modelBuilder.Entity("api_cinema_challenge.Models.Tickets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<bool>("Paid")
                        .HasColumnType("boolean")
                        .HasColumnName("paid");

                    b.Property<int>("PlayId")
                        .HasColumnType("integer")
                        .HasColumnName("play_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("PlayId");

                    b.ToTable("tickets");
                });

            modelBuilder.Entity("api_cinema_challenge.Models.Tickets", b =>
                {
                    b.HasOne("api_cinema_challenge.Models.Play", "Play")
                        .WithMany("Tickets")
                        .HasForeignKey("PlayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Play");
                });

            modelBuilder.Entity("api_cinema_challenge.Models.Play", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}