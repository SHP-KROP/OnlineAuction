﻿// <auto-generated />
using System;
using AuctionService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuctionService.Infrastructure.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    [Migration("20230728201953_AddedAscendingIndexOnAuctionStartTime")]
    partial class AddedAscendingIndexOnAuctionStartTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("auction")
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuctionService.Core.Entities.Auction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AuctionType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset?>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTimeOffset?>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("StartTime");

                    b.ToTable("Auctions", "auction");
                });

            modelBuilder.Entity("AuctionService.Core.Entities.AuctionItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ActualPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("AuctionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSellingNow")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<decimal>("MinimalBid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("StartingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("AuctionItem", "auction");
                });

            modelBuilder.Entity("AuctionService.Core.Entities.AuctionItemPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("AuctionItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuctionItemId");

                    b.ToTable("AuctionItemPhoto", "auction");
                });

            modelBuilder.Entity("AuctionService.Core.Entities.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ActualPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("AuctionItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuctionItemId");

                    b.ToTable("Bid", "auction");
                });

            modelBuilder.Entity("AuctionService.Core.Entities.AuctionItem", b =>
                {
                    b.HasOne("AuctionService.Core.Entities.Auction", null)
                        .WithMany("AuctionItems")
                        .HasForeignKey("AuctionId");
                });

            modelBuilder.Entity("AuctionService.Core.Entities.AuctionItemPhoto", b =>
                {
                    b.HasOne("AuctionService.Core.Entities.AuctionItem", null)
                        .WithMany("Photos")
                        .HasForeignKey("AuctionItemId");
                });

            modelBuilder.Entity("AuctionService.Core.Entities.Bid", b =>
                {
                    b.HasOne("AuctionService.Core.Entities.AuctionItem", null)
                        .WithMany("Bids")
                        .HasForeignKey("AuctionItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuctionService.Core.Entities.Auction", b =>
                {
                    b.Navigation("AuctionItems");
                });

            modelBuilder.Entity("AuctionService.Core.Entities.AuctionItem", b =>
                {
                    b.Navigation("Bids");

                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
