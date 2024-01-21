using CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Context
{
    public class Context:IdentityDbContext<AppUser>
    {
        public Context(DbContextOptions options) : base(options) { }


        public virtual DbSet<FishDisease> FishDiseases { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<FarmOwner> FarmOwners { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DetectDisease> Detects { get; set; }
       



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FarmOwner>(conf =>
            {
                conf.HasBaseType(typeof(AppUser));
            });
            builder.Entity<Doctor>(conf =>
            {
                conf.HasBaseType(typeof(AppUser));
            });
            builder.Entity<Admin>(conf =>
            {
                conf.HasBaseType(typeof(AppUser));
                conf.HasData(new Admin() { UserName= "admin",PasswordHash="admin" });
            });
            builder.Entity<IdentityRole>(conf =>
            {
                conf.HasData(
                    new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole() { Name = "FarmOwner", NormalizedName = "FARMOWNER" },
                    new IdentityRole() { Name = "Doctor", NormalizedName = "DOCTOR" }
                    );
                   
            });


        }

    }
}
