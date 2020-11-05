//-----------------------------------------------------------------------------
// <copyright file="Artist.cs">
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
        Name = nameof(Resources.Artist_Name),
        Description = nameof(Resources.Artist_Description),
        ResourceType = typeof(Resources)
    )]
    public sealed class Artist : ITrackable
    {
        [Display(
            Name = nameof(Resources.Artist_Id_Name),
            Description = nameof(Resources.Artist_Id_Description),
            ResourceType = typeof(Resources)
        )]
        public int Id { get; set; }

        [Display(
            Name = nameof(Resources.Artist_CreatedAt_Name),
            Description = nameof(Resources.Artist_CreatedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime CreatedAt { get; set; }

        [Display(
            Name = nameof(Resources.Artist_CreatedBy_Name),
            Description = nameof(Resources.Artist_CreatedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string CreatedBy { get; set; }

        [Display(
            Name = nameof(Resources.Artist_ModifiedAt_Name),
            Description = nameof(Resources.Artist_ModifiedAt_Description),
            ResourceType = typeof(Resources)
        )]
        public DateTime ModifiedAt { get; set; }

        [Display(
            Name = nameof(Resources.Artist_ModifiedBy_Name),
            Description = nameof(Resources.Artist_ModifiedBy_Description),
            ResourceType = typeof(Resources)
        )]
        public string ModifiedBy { get; set; }

        [Display(
            Name = nameof(Resources.Artist_Version_Name),
            Description = nameof(Resources.Artist_Version_Description),
            ResourceType = typeof(Resources)
        )]
        public int Version { get; set; }

        [Display(
            Name = nameof(Resources.Artist_Name_Name),
            Description = nameof(Resources.Artist_Name_Description),
            ResourceType = typeof(Resources)
        )]
        public string Name { get; set; }

        [Display(
            Name = nameof(Resources.Artist_NameKanji_Name),
            Description = nameof(Resources.Artist_NameKanji_Description),
            ResourceType = typeof(Resources)
        )]
        public string NameKanji { get; set; }

        [Display(
            Name = nameof(Resources.Artist_Company_Name),
            Description = nameof(Resources.Artist_Company_Description),
            ResourceType = typeof(Resources)
        )]
        public string Company { get; set; }
    }

    internal sealed class ArtistTypeConfiguration : IEntityTypeConfiguration<Artist>
    {
        private const string TABLE_NAME = "Artists";

        public void Configure(EntityTypeBuilder<Artist> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable(TABLE_NAME)
                .HasKey(x => x.Id);

            entityTypeBuilder
                .Property(x => x.Company)
                .HasMaxLength(100);

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
    }
}
