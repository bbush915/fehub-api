//-----------------------------------------------------------------------------
// <copyright file="ImportArtistsScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Models;
using FEHub.Utilities.Scripts.Base;

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace FEHub.Utilities.Scripts
{
    internal sealed class ImportArtistsScript : BaseScript, IDisposable
    {
        private readonly FehContext _dbContext;

        private readonly string _sourceFiile;

        public ImportArtistsScript(FehContext dbContext, string sourceFile)
        {
            this._dbContext = dbContext;

            this._sourceFiile = sourceFile;
        }

        public override async Task RunAsync()
        {
            var artists = this.Fetch();
            await this.ImportAsync(artists);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        private List<Artist> Fetch()
        {
            var artists = new List<Artist>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excelPackage = new ExcelPackage(new FileInfo(this._sourceFiile)))
            {
                var worksheet = excelPackage.Workbook.Worksheets["Artists"];

                for (var i = 2; i <= worksheet.Dimension.End.Row; ++i)
                {
                    var artist = new Artist()
                    {
                        Name = worksheet.Cells[i, 1].GetValue<string>(),
                        NameKanji = worksheet.Cells[i, 2].GetValue<string>(),
                        Company = worksheet.Cells[i, 3].GetValue<string>(),
                    };

                    if (string.IsNullOrEmpty(artist.NameKanji))
                    {
                        artist.NameKanji = null;
                    }

                    if (string.IsNullOrEmpty(artist.Company))
                    {
                        artist.Company = null;
                    }

                    artists.Add(artist);
                }
            }

            return artists;
        }
        
        private async Task ImportAsync(List<Artist> artists)
        {
            foreach (var artist in artists)
            {
                var existingArtist = await this._dbContext
                    .Artists
                    .SingleOrDefaultAsync(x => x.Name == artist.Name);

                if (existingArtist == null)
                {
                    await this._dbContext
                        .Artists
                        .AddAsync(artist);
                }
            }

            await this._dbContext.SaveChangesAsync();
        }
    }
}
