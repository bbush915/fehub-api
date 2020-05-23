//-----------------------------------------------------------------------------
// <copyright file="HeroVoiceActor.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Properties;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    [Display(
        Name = nameof(Resources.HeroVoiceActor_Name),
        Description = nameof(Resources.HeroVoiceActor_Description),
        ResourceType = typeof(Resources)
    )]
    public class HeroVoiceActor
    {
        #region Properties
        [Display(
            Name = nameof(Resources.HeroVoiceActor_Id_Name),
            Description = nameof(Resources.HeroVoiceActor_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public int Id { get; set; }

        [Display(
            Name = nameof(Resources.HeroVoiceActor_HeroId_Name),
            Description = nameof(Resources.HeroVoiceActor_HeroId_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid HeroId { get; set; }

        [Display(
            Name = nameof(Resources.HeroVoiceActor_VoiceActorId_Name),
            Description = nameof(Resources.HeroVoiceActor_VoiceActorId_Description),
            ResourceType = typeof(Resources)
        )]
        public int VoiceActorId { get; set; }

        [Display(
            Name = nameof(Resources.HeroVoiceActor_Language_Name),
            Description = nameof(Resources.HeroVoiceActor_Language_Description),
            ResourceType = typeof(Resources)
        )]
        public Languages Language { get; set; }

        [Display(
            Name = nameof(Resources.HeroVoiceActor_Sort_Name),
            Description = nameof(Resources.HeroVoiceActor_Sort_Description),
            ResourceType = typeof(Resources)
        )]
        public int Sort { get; set; }

        [Display(
            Name = nameof(Resources.HeroVoiceActor_VoiceActor_Name),
            Description = nameof(Resources.HeroVoiceActor_VoiceActor_Description),
            ResourceType = typeof(Resources)
        )]
        public virtual VoiceActor VoiceActor { get; set; }
        #endregion
    }

    internal sealed class HeroVoiceActorTypeConfiguration : IEntityTypeConfiguration<HeroVoiceActor>
    {
        #region Fields
        private const string TABLE_NAME = "HeroVoiceActors";
        #endregion

        #region Methods
        public void Configure(EntityTypeBuilder<HeroVoiceActor> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME);

            entityTypeBuilder
                .HasKey(x => x.Id);

            #region Navigation Properties
            entityTypeBuilder
                .HasOne(x => x.VoiceActor)
                .WithMany()
                .HasForeignKey(x => x.VoiceActorId);
            #endregion

            entityTypeBuilder
                .Property(x => x.Language)
                .HasConversion<int>();
        }
        #endregion
    }
}
