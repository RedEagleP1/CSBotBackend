using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace P1_Infrastructure.Database
{
    public class P1DatabaseContext : IdentityDbContext
    {
        public P1DatabaseContext(DbContextOptions<P1DatabaseContext> options) : base(options) { }
    }
}