//-----------------------------------------------------------------------------
// <copyright file="ExtractSkillAssetsScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.IO;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Utilities.Scripts.Base;

using OfficeOpenXml;

namespace FEHub.Utilities.Scripts
{
    internal sealed class ExtractSkillAssetsScript : BaseScript, IDisposable
    {
        private readonly FehContext _dbContext;

        private readonly string _sourceDirectory;
        private readonly string _targetDirectory;

        private readonly bool _overwrite;

        public ExtractSkillAssetsScript(FehContext dbContext, string sourceDirectory, string targetDirectory, bool overwrite = false) 
        {
            this._dbContext = dbContext;

            this._sourceDirectory = sourceDirectory;
            this._targetDirectory = targetDirectory;

            this._overwrite = overwrite;
        }

        public override Task RunAsync()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var excelPackage = new ExcelPackage(new FileInfo(Path.Combine(this._sourceDirectory, "SkillMapping.xlsx")));

            var worksheet = excelPackage.Workbook.Worksheets["Skills"];

            for (var i = 2; i <= worksheet.Dimension.End.Row; ++i)
            {
                var skillId = worksheet.Cells[i, 1].GetValue<string>();
                var skillName = worksheet.Cells[i, 2].GetValue<string>();

                var sheet = worksheet.Cells[i, 5].GetValue<int?>();
                var column = worksheet.Cells[i, 6].GetValue<int?>();
                var row = worksheet.Cells[i, 7].GetValue<int?>();

                Console.Out.WriteLine($"Processing skill: [Name: {skillName}]");

                var targetPath = Path.Combine(this._targetDirectory, skillId.ToLower());

                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }

                if (sheet == null || column == null || row == null)
                {
                    Console.Out.WriteLine("-------------------------");
                    continue;
                }

                var targetSkillDirectory = new DirectoryInfo(targetPath);

                var targetFilePath = Path.Combine(targetSkillDirectory.FullName, "icon.png");

                if (this._overwrite || !File.Exists(targetFilePath))
                {
                    File.Copy(Path.Combine(this._sourceDirectory, $"{sheet}.{column}.{row}.png"), targetFilePath, overwrite: this._overwrite);
                }

                Console.Out.WriteLine("-------------------------");
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
