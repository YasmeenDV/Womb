using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WOMB_Final.Models;

namespace WOMB_Final.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserViewModel>().ToTable("UserView");

            modelBuilder.Entity<UserViewModel>()
                .HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<WOMB_Final.Models.UserViewModel> UserViewModel { get; set; }
    }
}
