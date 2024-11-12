using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Logging;
using P1_Application.Boundaries;
using P1_Core.Entities;
using P1_Core.Entities.JoinTables;
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
        public virtual DbSet<DiscordCommand> DiscordCommands { get; set; }
        public virtual DbSet<DiscordCommandOptions> DiscordCommandOptions { get; set; }

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


            modelBuilder.Entity<DiscordCommand>()
                .HasMany<DiscordCommandOptions>()
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rule>()
                .HasMany(r => r.Conditions)
                .WithMany(c => c.Rules)
                .UsingEntity<ConditionRule>(
                    j => j.ToTable("ConditionRule"))
                .HasMany(r => r.Results)
                .WithMany(c => c.Rules)
                .UsingEntity<ResultRule>(
                    j => j.ToTable("ResultRule"))
                .HasMany(r => r.Triggers)
                .WithMany(c => c.Rules)
                .UsingEntity<TriggerRule>(
                    j => j.ToTable("TriggerRule"));

            modelBuilder.Entity<Condition>()
            .HasMany(c => c.Rules)
            .WithMany(r => r.Conditions);

            modelBuilder.Entity<Result>()
            .HasMany(c => c.Rules)
            .WithMany(r => r.Results);

            modelBuilder.Entity<Trigger>()
            .HasMany(c => c.Rules)
            .WithMany(r => r.Triggers);


            modelBuilder.Entity<ConditionRule>().HasKey(cr => new { cr.ConditionId, cr.RuleId });

            modelBuilder.Entity<ResultRule>().HasKey(rr => new { rr.ResultId, rr.RuleId });

            modelBuilder.Entity<TriggerRule>().HasKey(tr => new { tr.TriggerId, tr.RuleId });


            modelBuilder.Entity<DiscordUserTeam>().HasKey(ir => new { ir.TeamId, ir.DiscordUserId });

            modelBuilder.Entity<GameTeam>().HasKey(ir => new { ir.TeamId, ir.GameId });

            modelBuilder.Entity<TeamOrganization>().HasKey(ir => new { ir.OrganizationId, ir.TeamId });

            modelBuilder.Entity<OrganizationLegion>().HasKey(ir => new { ir.LegionId, ir.OrganizationId });


            modelBuilder.Entity<ItemResult>().HasKey(ir => new { ir.ItemId, ir.ResultId });

            modelBuilder.Entity<UserItem>().HasKey(ui => new { ui.UserId, ui.ItemId });

            modelBuilder.Entity<ItemResult>().HasKey(ir => new { ir.ItemId, ir.ResultId });

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
                //todo We need additional testing around this in order to identify the correct user ID is being retrieved on multiple requests across users
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