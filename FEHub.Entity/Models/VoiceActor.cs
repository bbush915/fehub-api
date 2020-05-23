//-----------------------------------------------------------------------------
// <copyright file="VoiceActor.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Interfaces;
using FEHub.Entity.Properties;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    public class VoiceActor : ITrackable
    {
        #region Properties
        [Display(
            Name = nameof(Resources.VoiceActor_Id_Name),
            Description = nameof(Resources.VoiceActor_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public int Id { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_CreatedAt_Name),
            Description = nameof(Resources.VoiceActor_CreatedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime CreatedAt { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_CreatedBy_Name),
            Description = nameof(Resources.VoiceActor_CreatedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string CreatedBy { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_ModifiedAt_Name),
            Description = nameof(Resources.VoiceActor_ModifiedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime ModifiedAt { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_ModifiedBy_Name),
            Description = nameof(Resources.VoiceActor_ModifiedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string ModifiedBy { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_Version_Name),
            Description = nameof(Resources.VoiceActor_Version_Description),
            ResourceType = typeof(Resources)
        )]
        public int Version { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_Name_Name),
            Description = nameof(Resources.VoiceActor_Name_Description),
            ResourceType = typeof(Resources)
        )]
        public string Name { get; set; }

        [Display(
            Name = nameof(Resources.VoiceActor_NameKanji_Name),
            Description = nameof(Resources.VoiceActor_NameKanji_Description),
            ResourceType = typeof(Resources)
        )]
        public string NameKanji { get; set; }
        #endregion
    }

    internal sealed class VoiceActorTypeConfiguration : IEntityTypeConfiguration<VoiceActor>
    {
        #region Fields
        private const string TABLE_NAME = "VoiceActors";
        #endregion

        #region Methods
        public void Configure(EntityTypeBuilder<VoiceActor> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.ModifiedBy)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.NameKanji)
                .HasMaxLength(100);
        }
        #endregion
    }
}
