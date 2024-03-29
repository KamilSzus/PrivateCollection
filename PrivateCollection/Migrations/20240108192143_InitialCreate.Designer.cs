﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PrivateCollection.Data;

#nullable disable

namespace PrivateCollection.Migrations
{
    [DbContext(typeof(PrivateCollectionContext))]
    [Migration("20240108192143_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PrivateCollection.Models.BoardGame", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PublishingHouse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BoardsGames");
                });

            modelBuilder.Entity("PrivateCollection.Models.BoardGameGenre", b =>
                {
                    b.Property<long>("BoardGameId")
                        .HasColumnType("bigint");

                    b.Property<long>("GenereId")
                        .HasColumnType("bigint");

                    b.HasKey("BoardGameId", "GenereId");

                    b.HasIndex("GenereId");

                    b.ToTable("BoardGameGenres");
                });

            modelBuilder.Entity("PrivateCollection.Models.BoardGameStats", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BoardGameId")
                        .HasColumnType("bigint");

                    b.Property<int?>("GameCount")
                        .HasColumnType("integer");

                    b.Property<TimeSpan?>("InGameTime")
                        .HasColumnType("interval");

                    b.Property<DateTime?>("LastGame")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("NumberOfWinGame")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId")
                        .IsUnique();

                    b.ToTable("BoardGameStats");
                });

            modelBuilder.Entity("PrivateCollection.Models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<List<string>>("Authors")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("boolean");

                    b.Property<TimeSpan?>("ReadTime")
                        .HasColumnType("interval");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("PrivateCollection.Models.BookGenre", b =>
                {
                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<long>("GenereId")
                        .HasColumnType("bigint");

                    b.HasKey("BookId", "GenereId");

                    b.HasIndex("GenereId");

                    b.ToTable("BookGenres");
                });

            modelBuilder.Entity("PrivateCollection.Models.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("GenreType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("PrivateCollection.Models.BoardGameGenre", b =>
                {
                    b.HasOne("PrivateCollection.Models.BoardGame", "BoardGame")
                        .WithMany("BoardGameGenre")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrivateCollection.Models.Genre", "Genre")
                        .WithMany("BoardGameGenres")
                        .HasForeignKey("GenereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardGame");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("PrivateCollection.Models.BoardGameStats", b =>
                {
                    b.HasOne("PrivateCollection.Models.BoardGame", null)
                        .WithOne("BoardGameStats")
                        .HasForeignKey("PrivateCollection.Models.BoardGameStats", "BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrivateCollection.Models.BookGenre", b =>
                {
                    b.HasOne("PrivateCollection.Models.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrivateCollection.Models.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("PrivateCollection.Models.BoardGame", b =>
                {
                    b.Navigation("BoardGameGenre");

                    b.Navigation("BoardGameStats");
                });

            modelBuilder.Entity("PrivateCollection.Models.Book", b =>
                {
                    b.Navigation("BookGenres");
                });

            modelBuilder.Entity("PrivateCollection.Models.Genre", b =>
                {
                    b.Navigation("BoardGameGenres");

                    b.Navigation("BookGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
