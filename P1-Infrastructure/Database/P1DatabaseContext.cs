using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P1_Core.Entities;

namespace P1_Infrastructure.Database
{
    public class P1DatabaseContext : IdentityDbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<UserCurrency> UserCurrencies { get; set; }
        public P1DatabaseContext(DbContextOptions<P1DatabaseContext> options) : base(options) { }
        public P1DatabaseContext() { }
    }
}