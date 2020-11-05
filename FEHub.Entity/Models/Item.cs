//-----------------------------------------------------------------------------
// <copyright file="Item.cs">
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
    [Display(
        Name = nameof(Resources.Item_Name),
        Description = nameof(Resources.Item_Description),
        ResourceType = typeof(Resources)
    )]
    public sealed class Item : ITrackable
    {
        [Display(
            Name = nameof(Resources.Item_Id_Name),
            Description = nameof(Resources.Item_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid Id { get; set; }

        [Display(
            Name = nameof(Resources.Item_CreatedAt_Name),
            Description = nameof(Resources.Item_CreatedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime CreatedAt { get; set; }

        [Display(
            Name = nameof(Resources.Item_CreatedBy_Name),
            Description = nameof(Resources.Item_CreatedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string CreatedBy { get; set; }

        [Display(
            Name = nameof(Resources.Item_ModifiedAt_Name),
            Description = nameof(Resources.Item_ModifiedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime ModifiedAt { get; set; }

        [Display(
            Name = nameof(Resources.Item_ModifiedBy_Name),
            Description = nameof(Resources.Item_ModifiedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string ModifiedBy { get; set; }

        [Display(
            Name = nameof(Resources.Item_Version_Name),
            Description = nameof(Resources.Item_Version_Description),
            ResourceType = typeof(Resources)
        )]
        public int Version { get; set; }

        [Display(
            Name = nameof(Resources.Item_Name_Name),
            Description = nameof(Resources.Item_Name_Description),
            ResourceType = typeof(Resources)
        )]
        public string Name { get; set; }

        [Display(
            Name = nameof(Resources.Item_Description_Name),
            Description = nameof(Resources.Item_Description_Description),
            ResourceType = typeof(Resources)
        )]
        public string Description { get; set; }
    }

    internal sealed class ItemTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        private const string TABLE_NAME = "Items";

        public void Configure(EntityTypeBuilder<Item> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(250);

            entityTypeBuilder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            entityTypeBuilder
                .Property(x => x.ModifiedBy)
                .IsRequired()
                .HasMaxLength(100);

            entityTypeBuilder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
