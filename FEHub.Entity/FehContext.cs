//-----------------------------------------------------------------------------
// <copyright file="FehContext.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;

using FEHub.Entity.Common;
using FEHub.Entity.Interfaces;
using FEHub.Entity.Models;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Entity
{
    public class FehContext : DbContext
    {
        public FehContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
        }

        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<HeroSkill> HeroSkills { get; set; }
        public DbSet<HeroVoiceActor> HeroVoiceActors { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillMovementType> SkillMovementTypes { get; set; }
        public DbSet<SkillWeaponEffectiveness> SkillWeaponEffectivenesses { get; set; }
        public DbSet<SkillWeaponType> SkillWeaponTypes { get; set; }
        public DbSet<VoiceActor> VoiceActors { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.UpdateTrackables();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.UpdateTrackables();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FehContext).Assembly);
        }

        private void UpdateTrackables()
        {
            var entries = this.ChangeTracker.Entries();

            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                        {
                            trackable.CreatedAt = utcNow;
                            trackable.CreatedBy = Constants.DefaultUser;

                            trackable.ModifiedAt = utcNow;
                            trackable.ModifiedBy = Constants.DefaultUser;

                            trackable.Version = 1;

                            break;
                        }

                        case EntityState.Modified:
                        {
                            trackable.ModifiedAt = utcNow;
                            trackable.ModifiedBy = Constants.DefaultUser;

                            trackable.Version += 1;

                            break;
                        }
                    }
                }
            }
        }
    }
}
