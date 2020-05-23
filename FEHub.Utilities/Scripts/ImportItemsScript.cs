//-----------------------------------------------------------------------------
// <copyright file="ImportItemsScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Models;
using FEHub.Utilities.Helpers;
using FEHub.Utilities.Scripts.Base;

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace FEHub.Utilities.Scripts
{
    internal sealed class ImportItemsScript : BaseScript, IDisposable
    {
        #region Fields
        private readonly FehContext _dbContext;

        private readonly string _sourceFiile;
        #endregion

        #region Constructors
        public ImportItemsScript(FehContextFactory dbContextFactory, string sourceFile)
        {
            this._dbContext = dbContextFactory.CreateDbContext();

            this._sourceFiile = sourceFile;
        }
        #endregion

        #region Methods
        public override async Task RunAsync()
        {
            var items = this.Fetch();
            await this.ImportAsync(items);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        private List<Item> Fetch()
        {
            var items = new List<Item>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excelPackage = new ExcelPackage(new FileInfo(this._sourceFiile)))
            {
                var worksheet = excelPackage.Workbook.Worksheets["Items"];

                for (var i = 2; i <= worksheet.Dimension.End.Row; ++i)
                {
                    var item = new Item()
                    {
                        Name = worksheet.Cells[i, 1].GetValue<string>(),
                        Description = worksheet.Cells[i, 2].GetValue<string>(),
                    };

                    item.Id = GuidHelpers.Create(item.Name);

                    items.Add(item);
                }
            }

            return items;
        }
        
        private async Task ImportAsync(List<Item> items)
        {
            foreach (var item in items)
            {
                var existingItem = await this._dbContext
                    .Items
                    .SingleOrDefaultAsync(x => x.Name == item.Name);

                if (existingItem == null)
                {
                    await this._dbContext
                        .Items
                        .AddAsync(item);
                }
            }

            await this._dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
