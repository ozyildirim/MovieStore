﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.DbOperations;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(MovieStoreDbContext))]
    [Migration("20230124232605_mapping7")]
    partial class mapping7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Models.Entities.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ActorId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("WebApi.Models.Entities.ActorMovie", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("integer");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("ActorMovies");
                });

            modelBuilder.Entity("WebApi.Models.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebApi.Models.Entities.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DirectorId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("DirectorId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("WebApi.Models.Entities.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MovieId"));

                    b.Property<int>("DirectorId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("Year")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("MovieId");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WebApi.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BuyerId")
                        .HasColumnType("integer");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("MovieId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebApi.Models.Entities.ActorMovie", b =>
                {
                    b.HasOne("WebApi.Models.Entities.Actor", "Actor")
                        .WithMany("ActorMovies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Models.Entities.Movie", "Movie")
                        .WithMany("ActorMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("WebApi.Models.Entities.Movie", b =>
                {
                    b.HasOne("WebApi.Models.Entities.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("WebApi.Models.Entities.Order", b =>
                {
                    b.HasOne("WebApi.Models.Entities.Customer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Models.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("WebApi.Models.Entities.Actor", b =>
                {
                    b.Navigation("ActorMovies");
                });

            modelBuilder.Entity("WebApi.Models.Entities.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("WebApi.Models.Entities.Movie", b =>
                {
                    b.Navigation("ActorMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
