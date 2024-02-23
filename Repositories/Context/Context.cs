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
    public class RepositoryContext:IdentityDbContext<AppUser>
    {
       
        public RepositoryContext(DbContextOptions options) : base(options) { }


        public virtual DbSet<FishDisease> FishDiseases { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<FarmOwner> FarmOwners { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DetectDisease> Detects { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }





        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Treatment>(conf => {
                conf.HasKey(t => new { t.DiseaseID, t.TreatmentDesc });
                conf.HasOne(d=>d.FishDisease).WithMany(d=>d.Treatment).IsRequired().OnDelete(deleteBehavior:DeleteBehavior.Cascade);
            
            });

            builder.Entity<RecommandationActions>(conf => {
                conf.HasKey(r => new { r.DiseaseID, r.Action });
                conf.HasOne(r => r.FishDisease).WithMany(r => r.RecommandationActions).IsRequired().OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            });

            builder.Entity<ImpactOnAquaculture>(conf => {
                conf.HasKey(i => new { i.DiseaseID, i.ImpactOnAquaculturee });
                conf.HasOne(i => i.FishDisease).WithMany(i => i.ImpactOnAquacultures).IsRequired().OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            });

            builder.Entity<Diagnosis>(conf => {
                conf.HasKey(d => new {d.DiseaseID, d.Diagones });
                conf.HasOne(d =>d.FishDisease).WithMany(d => d.Diagnosis).IsRequired().OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            });
            builder.Entity<ClinicalSigns>(conf => {
                conf.HasKey(cs => new { cs.DiseaseID, cs.Sign });
                conf.HasOne(cs => cs.FishDisease).WithMany(cs =>cs.ClinicalSigns).IsRequired().OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            });
            builder.Entity<CausativeAgents>(conf => {
                conf.HasKey(ca => new { ca.DiseaseID, ca.Agents });
                conf.HasOne(ca => ca.FishDisease).WithMany(ca => ca.CausativeAgents).IsRequired().OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            });
            builder.Entity<PreventionAndControll>(conf => {
                conf.HasKey(P => new { P.DiseaseID,P.Prevention });
                conf.HasOne(P => P.FishDisease).WithMany(P => P.PreventionAndControlls).IsRequired().OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            });

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
