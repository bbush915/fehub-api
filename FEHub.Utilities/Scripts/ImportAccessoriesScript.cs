//-----------------------------------------------------------------------------
// <copyright file="ImportAccessoriesScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Models;
using FEHub.Utilities.Helpers;
using FEHub.Utilities.Scripts.Base;

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace FEHub.Utilities.Scripts
{
    internal sealed class ImportAccessoriesScript : BaseScript, IDisposable
    {
        private readonly FehContext _dbContext;

        private readonly string _sourceFiile;

        public ImportAccessoriesScript(FehContext dbContext, string sourceFile)
        {
            this._dbContext = dbContext;

            this._sourceFiile = sourceFile;
        }

        public override async Task RunAsync()
        {
            var accessories = this.Fetch();
            await this.ImportAsync(accessories);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        private List<Accessory> Fetch()
        {
            var accessories = new List<Accessory>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excelPackage = new ExcelPackage(new FileInfo(this._sourceFiile)))
            {
                var worksheet = excelPackage.Workbook.Worksheets["Accessories"];

                for (var i = 2; i <= worksheet.Dimension.End.Row; ++i)
                {
                    var accessory = new Accessory()
                    {
                        Name = worksheet.Cells[i, 3].GetValue<string>(),
                        Description = worksheet.Cells[i, 4].GetValue<string>(),
                        AccessoryType = (AccessoryTypes)Enum.Parse(typeof(AccessoryTypes), worksheet.Cells[i, 2].GetValue<string>()),
                        Tag = worksheet.Cells[i, 1].GetValue<string>(),
                    };

                    accessory.Id = GuidHelpers.Create(accessory.Tag);

                    accessories.Add(accessory);
                }
            }

            return accessories;
        }
        
        private async Task ImportAsync(List<Accessory> accessories)
        {
            foreach (var accessory in accessories)
            {
                var existingAccessory = await this._dbContext
                    .Accessories
                    .SingleOrDefaultAsync(x => x.Tag == accessory.Tag);

                if (existingAccessory == null)
                {
                    await this._dbContext
                        .Accessories
                        .AddAsync(accessory);
                }
            }

            await this._dbContext.SaveChangesAsync();
        }
    }
}
