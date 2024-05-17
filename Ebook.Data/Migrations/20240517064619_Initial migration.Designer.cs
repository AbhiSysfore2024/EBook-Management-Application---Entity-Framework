﻿// <auto-generated />
using System;
using Ebook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ebook.Data.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240517064619_Initial migration")]
    partial class Initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.AuthorModel", b =>
                {
                    b.Property<Guid>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("AuthorID");

                    b.ToTable("EFCAuthor");
                });

            modelBuilder.Entity("Entities.BookAuthor", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("EFCBookAuthor");
                });

            modelBuilder.Entity("Entities.BookModel", b =>
                {
                    b.Property<Guid>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("AvgRating")
                        .HasColumnType("real");

                    b.Property<int>("BookGenre")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ISBN")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("Publication_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("BookID");

                    b.ToTable("EFCBooks");
                });

            modelBuilder.Entity("Entities.LoginRequest", b =>
                {
                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("EFCCredentials");
                });

            modelBuilder.Entity("Entities.AuthorModel", b =>
                {
                    b.OwnsOne("Entities.AuthorName", "Name", b1 =>
                        {
                            b1.Property<Guid>("AuthorModelAuthorID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AuthorModelAuthorID");

                            b1.ToTable("EFCAuthor");

                            b1.WithOwner()
                                .HasForeignKey("AuthorModelAuthorID");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.BookAuthor", b =>
                {
                    b.HasOne("Entities.AuthorModel", "Author")
                        .WithMany("BookAuthor")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.BookModel", "Book")
                        .WithMany("BookAuthor")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Entities.AuthorModel", b =>
                {
                    b.Navigation("BookAuthor");
                });

            modelBuilder.Entity("Entities.BookModel", b =>
                {
                    b.Navigation("BookAuthor");
                });
#pragma warning restore 612, 618
        }
    }
}
