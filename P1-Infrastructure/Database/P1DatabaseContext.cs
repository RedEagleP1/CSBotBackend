using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P1_Core.Entities;
using P1_Infrastructure.Identity;

namespace P1_Infrastructure.Database
{
    public class P1DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        // public virtual DbSet<Currency> Currencies { get; set; }
        // public virtual DbSet<UserCurrency> UserCurrencies { get; set; }
        public P1DatabaseContext(DbContextOptions<P1DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            base.OnModelCreating(modelBuilder);
        }
        // For testing purposes
        // public P1DatabaseContext() { }
    }
}