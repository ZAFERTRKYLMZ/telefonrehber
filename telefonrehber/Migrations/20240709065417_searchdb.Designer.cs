﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using telefonrehber.Data;

#nullable disable

namespace telefonrehber.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240709065417_searchdb")]
    partial class searchdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("telefonrehber.Models.SearchHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SearchDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SearchHistories");
                });

            modelBuilder.Entity("telefonrehber.Models.kisi", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("telefon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("kisiler");
                });
#pragma warning restore 612, 618
        }
    }
}
