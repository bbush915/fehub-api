//-----------------------------------------------------------------------------
// <copyright file="HeroSkill.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Properties;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    [Display(
        Name = nameof(Resources.HeroSkill_Name),
        Description = nameof(Resources.HeroSkill_Description),
        ResourceType = typeof(Resources)
    )]
    public class HeroSkill
    {
        #region Properties
        [Display(
            Name = nameof(Resources.HeroSkill_Id_Name),
            Description = nameof(Resources.HeroSkill_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public int Id { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_HeroId_Name),
            Description = nameof(Resources.HeroSkill_HeroId_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid HeroId { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_SkillId_Name),
            Description = nameof(Resources.HeroSkill_SkillId_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid SkillId { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_SkillPosition_Name),
            Description = nameof(Resources.HeroSkill_SkillPosition_Description),
            ResourceType = typeof(Resources)
        )]
        public int SkillPosition { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_DefaultRarity_Name),
            Description = nameof(Resources.HeroSkill_DefaultRarity_Description),
            ResourceType = typeof(Resources)
        )]
        public int? DefaultRarity { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_UnlockRarity_Name),
            Description = nameof(Resources.HeroSkill_UnlockRarity_Description),
            ResourceType = typeof(Resources)
        )]
        public int UnlockRarity { get; set; }

        [Display(
            Name = nameof(Resources.HeroSkill_Skill_Name),
            Description = nameof(Resources.HeroSkill_Skill_Description),
            ResourceType = typeof(Resources)
        )]
        public virtual Skill Skill { get; set; }
        #endregion
    }

    internal sealed class HeroSkillTypeConfiguration : IEntityTypeConfiguration<HeroSkill>
    {
        #region Fields
        private const string TABLE_NAME = "HeroSkills";
        #endregion

        #region Methods
        public void Configure(EntityTypeBuilder<HeroSkill> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .HasOne(x => x.Skill)
                .WithMany()
                .HasForeignKey(x => x.SkillId);
        }
        #endregion
    }
}
