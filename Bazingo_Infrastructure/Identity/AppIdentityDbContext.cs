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
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ✅ إعدادات متقدمة للمستخدم
            builder.Entity<AppUser>(entity =>
            {
                entity.Property(u => u.FirstName)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(u => u.LastName)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(u => u.UserType)
                      .HasMaxLength(20)
                      .HasDefaultValue("Seller");

                entity.Property(u => u.IsVerified)
                      .HasDefaultValue(false);

                entity.HasIndex(u => u.Email).IsUnique();
            });
        }
    }
}
