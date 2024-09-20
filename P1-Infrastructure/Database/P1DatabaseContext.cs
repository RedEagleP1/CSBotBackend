using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using P1_Core.Entities;
using P1_Infrastructure.Identity;

namespace P1_Infrastructure.Database
{
    public class P1DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<Rule> Conditions { get; set; }
        public P1DatabaseContext(DbContextOptions<P1DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rule>()
            .HasMany(r => r.Conditions)
            .WithMany(c => c.Rules);

            modelBuilder.Entity<Condition>()
            .HasMany(c => c.Rules)
            .WithMany(r => r.Conditions);

            modelBuilder.Entity<Result>()
            .HasMany(r => r.Rules)
            .WithMany(r => r.Results);

        }
        // For testing purposes
        // public P1DatabaseContext() { }
    }
}