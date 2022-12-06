using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Models;
using FEHub.Utilities.Scripts.Base;

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace FEHub.Utilities.Scripts;

internal sealed class ImportVoiceActorsScript : BaseScript, IDisposable
{
    private readonly FehContext _dbContext;

    private readonly string _sourceFiile;

    public ImportVoiceActorsScript(FehContext dbContext, string sourceFile)
    {
        this._dbContext = dbContext;

        this._sourceFiile = sourceFile;
    }

    public override async Task RunAsync()
    {
        var voiceActors = this.Fetch();
        await this.ImportAsync(voiceActors);
    }

    public void Dispose()
    {
        this._dbContext.Dispose();
    }

    private List<VoiceActor> Fetch()
    {
        var voiceActors = new List<VoiceActor>();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var excelPackage = new ExcelPackage(new FileInfo(this._sourceFiile)))
        {
            var worksheet = excelPackage.Workbook.Worksheets["VoiceActors"];

            for (var i = 2; i <= worksheet.Dimension.End.Row; ++i)
            {
                var voiceActor = new VoiceActor()
                {
                    Name = worksheet.Cells[i, 1].GetValue<string>(),
                    NameKanji = worksheet.Cells[i, 2].GetValue<string>(),
                };

                if (string.IsNullOrEmpty(voiceActor.NameKanji))
                {
                    voiceActor.NameKanji = null;
                }

                voiceActors.Add(voiceActor);
            }
        }

        return voiceActors;
    }

    private async Task ImportAsync(List<VoiceActor> voiceActors)
    {
        foreach (var voiceActor in voiceActors)
        {
            var existingVoiceActor = await this._dbContext
                .VoiceActors
                .SingleOrDefaultAsync(x => x.Name == voiceActor.Name);

            if (existingVoiceActor == null)
            {
                await this._dbContext
                    .VoiceActors
                    .AddAsync(voiceActor);
            }
        }

        await this._dbContext.SaveChangesAsync();
    }
}
