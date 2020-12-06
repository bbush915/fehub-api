//-----------------------------------------------------------------------------
// <copyright file="SkillMovementType.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;
using FEHub.Entity.Properties;

using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    [Display(
        Name = nameof(Resources.SkillMovementType_Name),
        Description = nameof(Resources.SkillMovementType_Description),
        ResourceType = typeof(Resources)
    )]
    public sealed class SkillMovementType
    {
        [Display(
            Name = nameof(Resources.SkillMovementType_Id_Name),
            Description = nameof(Resources.SkillMovementType_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public int Id { get; set; }

        [Display(
            Name = nameof(Resources.SkillMovementType_SkillId_Name),
            Description = nameof(Resources.SkillMovementType_SkillId_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid SkillId { get; set; }

        [Display(
            Name = nameof(Resources.SkillMovementType_MovementType_Name),
            Description = nameof(Resources.SkillMovementType_MovementType_Description),
            ResourceType = typeof(Resources)
        )]
        public MovementTypes MovementType { get; set; }
    }

    internal sealed class SkillMovementTypeTypeConfiguration : IEntityTypeConfiguration<SkillMovementType>
    {
        private const string TABLE_NAME = "SkillMovementTypes";

        public void Configure(EntityTypeBuilder<SkillMovementType> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .Property(x => x.MovementType)
                .HasConversion<int>();
        }
    }
}

namespace FEHub.Entity.Common.Helpers
{
    public static partial class FakeHelpers
    {
        public static Faker<SkillMovementType> SkillMovementType(
            int? id = null,
            Guid? skillId = null,
            MovementTypes? movementType = null
        )
        {
            var skillMovementTypeFaker = new Faker<SkillMovementType>()
                .RuleFor(x => x.Id, (faker) => id ?? faker.Random.Int(1))
                .RuleFor(x => x.SkillId, () => skillId ?? Guid.NewGuid())
                .RuleFor(x => x.MovementType, (faker) => movementType ?? faker.PickRandom<MovementTypes>());

            return skillMovementTypeFaker;
        }
    }
}