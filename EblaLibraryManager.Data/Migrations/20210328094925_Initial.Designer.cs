﻿// <auto-generated />
using System;
using EblaLibraryManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EblaLibraryManager.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210328094925_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EblaLibraryManager.Data.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Born")
                        .HasColumnType("date");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Death")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.AvailabilityStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AvailabilityStatus");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("AvailabilityStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Borrowed")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("date");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TotalPages")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("AvailabilityStatusId");

                    b.HasIndex("GenreId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.Lending", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("date");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("date");

                    b.Property<DateTime?>("Returned")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Lending");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("date");

                    b.Property<int>("ReservationStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReservationStatusId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.ReservationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ReservationStatus");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.Book", b =>
                {
                    b.HasOne("EblaLibraryManager.Data.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK_Book_Author")
                        .IsRequired();

                    b.HasOne("EblaLibraryManager.Data.Models.AvailabilityStatus", "AvailabilityStatus")
                        .WithMany("Books")
                        .HasForeignKey("AvailabilityStatusId")
                        .HasConstraintName("FK_Book_AvailabilityStatus")
                        .IsRequired();

                    b.HasOne("EblaLibraryManager.Data.Models.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_Book_Genre")
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("AvailabilityStatus");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.Lending", b =>
                {
                    b.HasOne("EblaLibraryManager.Data.Models.Book", "Book")
                        .WithMany("Lendings")
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_Lending_Book")
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.Reservation", b =>
                {
                    b.HasOne("EblaLibraryManager.Data.Models.Book", "Book")
                        .WithMany("Reservations")
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_Reservation_Book")
                        .IsRequired();

                    b.HasOne("EblaLibraryManager.Data.Models.ReservationStatus", "ReservationStatus")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservationStatusId")
                        .HasConstraintName("FK_Reservation_ReservationStatus")
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("ReservationStatus");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.AvailabilityStatus", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.Book", b =>
                {
                    b.Navigation("Lendings");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("EblaLibraryManager.Data.Models.ReservationStatus", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}