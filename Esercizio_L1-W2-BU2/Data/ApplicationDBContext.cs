using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Esercizio_L1_W2_BU2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Esercizio_L1_W2_BU2.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().Property(p => p.DataDiIscrizione).HasDefaultValueSql("GETDATE()").IsRequired(true);
            modelBuilder.Entity<ApplicationUserRole>().Property(p => p.Date).HasDefaultValueSql("GETDATE()").IsRequired(true);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(p => p.User).WithMany(p => p.ApplicationUserRoles).HasForeignKey(p => p.UserId);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(p => p.Role).WithMany(p => p.ApplicationUserRoles).HasForeignKey(p => p.RoleId);
            modelBuilder.Entity<Student>().HasData(
            );
        }
    }
}
