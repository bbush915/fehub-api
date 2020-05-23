//-----------------------------------------------------------------------------
// <copyright file="Accessory.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Interfaces;
using FEHub.Entity.Properties;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEHub.Entity.Models
{
    [Display(
        Name = nameof(Resources.Accessory_Name),
        Description = nameof(Resources.Accessory_Description),
        ResourceType = typeof(Resources)
    )]
    public class Accessory : ITrackable
    {
        #region Properties
        [Display(
            Name = nameof(Resources.Accessory_Id_Name),
            Description = nameof(Resources.Accessory_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public Guid Id { get; set; }

        [Display(
            Name = nameof(Resources.Accessory_CreatedAt_Name),
            Description = nameof(Resources.Accessory_CreatedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime CreatedAt { get; set; }

        [Display(
            Name = nameof(Resources.Accessory_CreatedBy_Name),
            Description = nameof(Resources.Accessory_CreatedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string CreatedBy { get; set; }

        [Display(
            Name = nameof(Resources.Accessory_ModifiedAt_Name),
            Description = nameof(Resources.Accessory_ModifiedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime ModifiedAt { get; set; }

        [Display(
            Name = nameof(Resources.Accessory_ModifiedBy_Name),
            Description = nameof(Resources.Accessory_ModifiedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string ModifiedBy { get; set; }

        [Display(
            Name = nameof(Resources.Accessory_Version_Name),
            Description = nameof(Resources.Accessory_Version_Description),
            ResourceType = typeof(Resources)
        )]
        public int Version { get; set; }

        [Display(
            Name = nameof(Resources.Accessory_Name_Name),
            Description = nameof(Resources.Accessory_Name_Description),
            ResourceType = typeof(Resources)
        )]
        public string Name { get; set; }

        [Display(
            Name = nameof(Resources.Accessory_Description_Name),
            Description = nameof(Resources.Accessory_Description_Description),
            ResourceType = typeof(Resources)
        )]
        public string Description { get; set; }

        [Display(
            Name = nameof(Resources.Accessory_AccessoryType_Name),
            Description = nameof(Resources.Accessory_AccessoryType_Description),
            ResourceType = typeof(Resources)
        )]
        public AccessoryTypes AccessoryType { get; set; }

        [Display(
            Name = nameof(Resources.Accessory_Tag_Name),
            Description = nameof(Resources.Accessory_Tag_Description),
            ResourceType = typeof(Resources)
        )]
        public string Tag { get; set; }
        #endregion
    }

    internal sealed class AccessoryTypeConfiguration : IEntityTypeConfiguration<Accessory>
    {
        #region Fields
        private const string TABLE_NAME = "Accessories";
        #endregion

        #region Methods
        public void Configure(EntityTypeBuilder<Accessory> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .Property(x => x.AccessoryType)
                .HasConversion<int>();

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

            entityTypeBuilder
                .Property(x => x.Tag)
                .IsRequired()
                .HasMaxLength(100);
        }
        #endregion
    }
}
