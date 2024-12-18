﻿// <auto-generated />
using System;
using Bazingo_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bazingo_Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241217211432_addfirstandlastnameMIG")]
    partial class addfirstandlastnameMIG
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bazingo_Core.Models.Auction", b =>
                {
                    b.Property<int>("AuctionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuctionID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<decimal>("StartPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WinnerID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AuctionID");

                    b.HasIndex("ProductID")
                        .IsUnique();

                    b.HasIndex("WinnerID");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Bid", b =>
                {
                    b.Property<int>("BidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BidID"));

                    b.Property<int>("AuctionID")
                        .HasColumnType("int");

                    b.Property<decimal>("BidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BidID");

                    b.HasIndex("AuctionID");

                    b.HasIndex("UserID");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ParentCategoryID")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.HasIndex("ParentCategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Bazingo_Core.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityID"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CityID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Complaint", b =>
                {
                    b.Property<int>("ComplaintID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplaintID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ComplaintID");

                    b.HasIndex("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Escrow", b =>
                {
                    b.Property<int>("EscrowID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EscrowID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EscrowID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.ToTable("Escrows");
                });

            modelBuilder.Entity("Bazingo_Core.Models.ItemsUnit", b =>
                {
                    b.Property<int>("ItemUnitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemUnitID"));

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<decimal>("QuantityPerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitID")
                        .HasColumnType("int");

                    b.Property<int?>("UnitID1")
                        .HasColumnType("int");

                    b.HasKey("ItemUnitID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UnitID");

                    b.HasIndex("UnitID1");

                    b.ToTable("ItemsUnits");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<string>("BuyerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.HasIndex("BuyerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Bazingo_Core.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailID"));

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SellerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("VideoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SellerID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReviewID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Shipping", b =>
                {
                    b.Property<int>("ShippingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShippingID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ZoneID")
                        .HasColumnType("int");

                    b.Property<int?>("ZoneID1")
                        .HasColumnType("int");

                    b.HasKey("ShippingID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.HasIndex("ZoneID");

                    b.HasIndex("ZoneID1");

                    b.ToTable("Shippings");
                });

            modelBuilder.Entity("Bazingo_Core.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartItemID"));

                    b.Property<string>("BuyerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ShoppingCartItemID");

                    b.HasIndex("BuyerID");

                    b.HasIndex("ProductID");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Unit", b =>
                {
                    b.Property<int>("UnitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UnitID");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Bazingo_Core.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("NumericId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Bazingo_Core.Models.Zone", b =>
                {
                    b.Property<int>("ZoneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZoneID"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("ZoneName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ZoneID");

                    b.HasIndex("CityID");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Bazingo_Core.Models.Auction", b =>
                {
                    b.HasOne("Bazingo_Core.Models.Product", "Product")
                        .WithOne("Auction")
                        .HasForeignKey("Bazingo_Core.Models.Auction", "ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.User", "Winner")
                        .WithMany("WonAuctions")
                        .HasForeignKey("WinnerID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Product");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Bid", b =>
                {
                    b.HasOne("Bazingo_Core.Models.Auction", "Auction")
                        .WithMany("Bids")
                        .HasForeignKey("AuctionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.User", "User")
                        .WithMany("Bids")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Category", b =>
                {
                    b.HasOne("Bazingo_Core.Models.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Complaint", b =>
                {
                    b.HasOne("Bazingo_Core.Models.Order", "Order")
                        .WithMany("Complaints")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.User", "User")
                        .WithMany("Complaints")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Escrow", b =>
                {
                    b.HasOne("Bazingo_Core.Models.Order", "Order")
                        .WithOne("Escrow")
                        .HasForeignKey("Bazingo_Core.Models.Escrow", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Bazingo_Core.Models.ItemsUnit", b =>
                {
                    b.HasOne("Bazingo_Core.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.Unit", null)
                        .WithMany("ItemUnits")
                        .HasForeignKey("UnitID1");

                    b.Navigation("Product");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Order", b =>
                {
                    b.HasOne("Bazingo_Core.Models.User", "Buyer")
                        .WithMany("Orders")
                        .HasForeignKey("BuyerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("Bazingo_Core.Models.OrderDetail", b =>
                {
                    b.HasOne("Bazingo_Core.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Payment", b =>
                {
                    b.HasOne("Bazingo_Core.Models.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("Bazingo_Core.Models.Payment", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Product", b =>
                {
                    b.HasOne("Bazingo_Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.User", "Seller")
                        .WithMany("Products")
                        .HasForeignKey("SellerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Review", b =>
                {
                    b.HasOne("Bazingo_Core.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Shipping", b =>
                {
                    b.HasOne("Bazingo_Core.Models.Order", "Order")
                        .WithOne("Shipping")
                        .HasForeignKey("Bazingo_Core.Models.Shipping", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.Zone", "Zone")
                        .WithMany()
                        .HasForeignKey("ZoneID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.Zone", null)
                        .WithMany("Shippings")
                        .HasForeignKey("ZoneID1");

                    b.Navigation("Order");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("Bazingo_Core.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("Bazingo_Core.Models.User", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Zone", b =>
                {
                    b.HasOne("Bazingo_Core.Models.City", "City")
                        .WithMany("Zones")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Bazingo_Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Bazingo_Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazingo_Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Bazingo_Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bazingo_Core.Models.Auction", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Bazingo_Core.Models.City", b =>
                {
                    b.Navigation("Zones");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Order", b =>
                {
                    b.Navigation("Complaints");

                    b.Navigation("Escrow")
                        .IsRequired();

                    b.Navigation("OrderDetails");

                    b.Navigation("Payment")
                        .IsRequired();

                    b.Navigation("Shipping")
                        .IsRequired();
                });

            modelBuilder.Entity("Bazingo_Core.Models.Product", b =>
                {
                    b.Navigation("Auction")
                        .IsRequired();

                    b.Navigation("OrderDetails");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Unit", b =>
                {
                    b.Navigation("ItemUnits");
                });

            modelBuilder.Entity("Bazingo_Core.Models.User", b =>
                {
                    b.Navigation("Bids");

                    b.Navigation("Complaints");

                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("Reviews");

                    b.Navigation("WonAuctions");
                });

            modelBuilder.Entity("Bazingo_Core.Models.Zone", b =>
                {
                    b.Navigation("Shippings");
                });
#pragma warning restore 612, 618
        }
    }
}