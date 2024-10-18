using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Logging;
using P1_Application.Boundaries;
using P1_Core.Entities;
using P1_Core.Interfaces;
using P1_Infrastructure.Identity;

namespace P1_Infrastructure.Database
{
    public class P1DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Trigger> Triggers { get; set; }
        public virtual DbSet<DiscordUser> DiscordUsers { get; set; }
        public virtual DbSet<UserMetaData> UserMetaData { get; set; }
        public virtual DbSet<UserItem> UserItems { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<ItemResult> ItemResults { get; set; }
        public virtual DbSet<Organization> OrganizationUsers { get; set; }
        public virtual DbSet<ResultRule> ResultRules { get; set; }

        private readonly ApplicationContext _customContext;
        private readonly ILogger<P1DatabaseContext> _logger;
        private readonly IHttpContextAccessor _accessor;
        public P1DatabaseContext(DbContextOptions<P1DatabaseContext> options,
        ApplicationContext customContext,
        ILogger<P1DatabaseContext> logger, IHttpContextAccessor accessor) : base(options)
        {
            _customContext = customContext;
            _logger = logger;
            _accessor = accessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rule>()
                .HasMany(r => r.Conditions)
                .WithMany(c => c.Rules)
                .UsingEntity<Dictionary<string, object>>(
                    "ConditionRule",
                    j => j.HasOne<Condition>().WithMany().HasForeignKey("ConditionsId"),
                    j => j.HasOne<Rule>().WithMany().HasForeignKey("RulesId"),
                    j => j.HasOne<Result>().WithMany().HasForeignKey("ResultsId"));

            modelBuilder.Entity<Condition>()
            .HasMany(c => c.Rules)
            .WithMany(r => r.Conditions);

            modelBuilder.Entity<UserItem>().HasKey(ui => new { ui.UserId, ui.ItemId });

            modelBuilder.Entity<ItemResult>().HasKey(ir => new { ir.ItemId, ir.ResultId });

            modelBuilder.Entity<ResultRule>().HasKey(rr => new { rr.ResultsId, rr.RulesId });

        }

        //TODO add error handling
        public override int SaveChanges()
        {

            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity &&
            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var entity = (BaseEntity)entityEntry.Entity;
                var now = DateTime.UtcNow;
                var userId = _customContext.UserId;
                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt = now;
                    entity.CreatedBy = userId;
                }
                else
                {
                    entity.UpdatedAt = now;
                    entity.UpdatedBy = userId;
                }
            }

            return base.SaveChanges();
        }
    }
}