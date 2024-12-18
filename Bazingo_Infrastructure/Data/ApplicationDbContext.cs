using Bazingo_Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets: تعريف جميع الجداول
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Escrow> Escrows { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ItemsUnit> ItemsUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User Entity Configuration
            builder.Entity<User>(user =>
            {
                user.HasMany(u => u.Products)
                    .WithOne(p => p.Seller)
                    .HasForeignKey(p => p.SellerID)
                    .OnDelete(DeleteBehavior.Restrict);

                user.HasMany(u => u.Orders)
                    .WithOne(o => o.Buyer)
                    .HasForeignKey(o => o.BuyerID)
                    .OnDelete(DeleteBehavior.Restrict);

                user.HasMany(u => u.Reviews)
                    .WithOne(r => r.User)
                    .HasForeignKey(r => r.UserID)
                    .OnDelete(DeleteBehavior.Cascade);

                user.HasMany(u => u.Complaints)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.UserID)
                    .OnDelete(DeleteBehavior.Cascade);

                user.HasMany(u => u.Bids)
                    .WithOne(b => b.User)
                    .HasForeignKey(b => b.UserID)
                    .OnDelete(DeleteBehavior.Cascade);

                user.HasMany(u => u.WonAuctions)
                    .WithOne(a => a.Winner)
                    .HasForeignKey(a => a.WinnerID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Product Entity Configuration
            builder.Entity<Product>(product =>
            {
                product.HasOne(p => p.Category)
                       .WithMany(c => c.Products)
                       .HasForeignKey(p => p.CategoryID)
                       .OnDelete(DeleteBehavior.Restrict);
            });

            // Category Entity Configuration (Self-Referencing)
            builder.Entity<Category>(category =>
            {
                category.HasOne(c => c.ParentCategory)
                        .WithMany(c => c.SubCategories)
                        .HasForeignKey(c => c.ParentCategoryID)
                        .IsRequired(false)
                        .OnDelete(DeleteBehavior.Restrict);
            });

            // Order and OrderDetail Configuration
            builder.Entity<OrderDetail>(orderDetail =>
            {
                orderDetail.HasOne(od => od.Order)
                           .WithMany(o => o.OrderDetails)
                           .HasForeignKey(od => od.OrderID)
                           .OnDelete(DeleteBehavior.Cascade);

                orderDetail.HasOne(od => od.Product)
                           .WithMany(p => p.OrderDetails)
                           .HasForeignKey(od => od.ProductID)
                           .OnDelete(DeleteBehavior.Cascade);
            });

            // Auction and Bid Configuration
            builder.Entity<Auction>(auction =>
            {
                auction.HasOne(a => a.Product)
                       .WithOne(p => p.Auction)
                       .HasForeignKey<Auction>(a => a.ProductID)
                       .OnDelete(DeleteBehavior.Restrict);

                auction.HasOne(a => a.Winner)
                       .WithMany(u => u.WonAuctions)
                       .HasForeignKey(a => a.WinnerID)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Bid>(bid =>
            {
                bid.HasOne(b => b.Auction)
                   .WithMany(a => a.Bids)
                   .HasForeignKey(b => b.AuctionID)
                   .OnDelete(DeleteBehavior.Cascade);

                bid.HasOne(b => b.User)
                   .WithMany(u => u.Bids)
                   .HasForeignKey(b => b.UserID)
                   .OnDelete(DeleteBehavior.Cascade);
            });

            // Shipping and Zones Configuration
            builder.Entity<Shipping>(shipping =>
            {
                shipping.HasOne(s => s.Zone)
                        .WithMany()
                        .HasForeignKey(s => s.ZoneID)
                        .OnDelete(DeleteBehavior.Restrict);
            });

            // ItemsUnits Configuration
            builder.Entity<ItemsUnit>(itemsUnit =>
            {
                itemsUnit.HasOne(iu => iu.Product)
                         .WithMany()
                         .HasForeignKey(iu => iu.ProductID)
                         .OnDelete(DeleteBehavior.Cascade);

                itemsUnit.HasOne(iu => iu.Unit)
                         .WithMany()
                         .HasForeignKey(iu => iu.UnitID)
                         .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<ShoppingCartItem>(entity =>
            {
                entity.HasOne(sci => sci.Buyer)
                      .WithMany()
                      .HasForeignKey(sci => sci.BuyerID)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(sci => sci.Product)
                      .WithMany()
                      .HasForeignKey(sci => sci.ProductID)
                      .IsRequired();
            });
        }
    }
}
