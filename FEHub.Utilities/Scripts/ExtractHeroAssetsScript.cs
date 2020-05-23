//-----------------------------------------------------------------------------
// <copyright file="ExtractHeroAssetsScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using FEHub.Entity;
using FEHub.Entity.Models;
using FEHub.Utilities.Scripts.Base;

using Microsoft.EntityFrameworkCore;

namespace FEHub.Utilities.Scripts
{
    internal sealed class ExtractHeroAssetsScript : BaseScript, IDisposable
    {
        #region Fields
        private readonly FehContext _dbContext;

        private readonly string _sourceDirectory;
        private readonly string _targetDirectory;

        private readonly bool _overwrite;
        #endregion

        #region Constructors
        public ExtractHeroAssetsScript(FehContextFactory dbContextFactory, string sourceDirectory, string targetDirectory, bool overwrite = false) 
        {
            this._dbContext = dbContextFactory.CreateDbContext();

            this._sourceDirectory = sourceDirectory;
            this._targetDirectory = targetDirectory;

            this._overwrite = overwrite;
        }
        #endregion

        #region Methods
        public override async Task RunAsync()
        {
            var heroes = await this._dbContext
                .Heroes
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Title)
                .ToListAsync();

            var heroGroups = heroes
                .GroupBy(x => x.Name);

            foreach (var heroGroup in heroGroups)
            {
                var hasAlternates = heroGroup.Count() > 1;
                
                foreach (var hero in heroGroup)
                {
                    Console.Out.WriteLine($"Processing hero: [Name: {hero.Name}, Title: {hero.Title}]");

                    this.CopyArtFiles(hero, hasAlternates);
                    this.CopySpriteFiles(hero, hasAlternates);
                    this.CopyEnglishVoiceFiles(hero, hasAlternates);
                    this.CopyJapaneseVoiceFiles(hero, hasAlternates);

                    Console.Out.WriteLine("-------------------------");
                }
            }
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        private void CopyArtFiles(Hero hero, bool hasAlternates)
        {
            Console.Out.WriteLine("Copying art files...");

            var sourceHeroDirectory = this.GetDirectory("Character Art & Sprites", hero, hasAlternates);

            if (!sourceHeroDirectory.Exists)
            {
                Console.Error.WriteLine($"Unable to locate source directory for hero: [Name: {hero.Name}, Title: {hero.Title}]");
                return;
            }

            var targetPath = Path.Combine(this._targetDirectory, hero.Id.ToString());

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            var targetHeroDirectory = new DirectoryInfo(targetPath);

            if (!this.CopyFiles(sourceHeroDirectory, targetHeroDirectory, "Face.png", "default.png"))
            {
                Console.Error.WriteLine($"Unable to locate image: [Face.png] for hero: [Name: {hero.Name}, Title: {hero.Title}]");
            }

            if (!this.CopyFiles(sourceHeroDirectory, targetHeroDirectory, "BtlFace.png", "attack.png"))
            {
                Console.Error.WriteLine($"Unable to locate image: [BtlFace.png] for hero: [Name: {hero.Name}, Title: {hero.Title}]");
            }

            if (!this.CopyFiles(sourceHeroDirectory, targetHeroDirectory, "BtlFace_C.png", "special.png"))
            {
                Console.Error.WriteLine($"Unable to locate image: [BtlFace_C.png] for hero: [Name: {hero.Name}, Title: {hero.Title}]");
            }

            if (!this.CopyFiles(sourceHeroDirectory, targetHeroDirectory, "BtlFace_D.png", "injured.png"))
            {
                Console.Error.WriteLine($"Unable to locate image: [BtlFace_D.png] for hero: [Name: {hero.Name}, Title: {hero.Title}]");
            }

            if (!this.CopyFiles(sourceHeroDirectory, targetHeroDirectory, "Face_FC.png", "thumbnail.png"))
            {
                Console.Error.WriteLine($"Unable to locate image: [Face_FC.png] for hero: [Name: {hero.Name}, Title: {hero.Title}]");
            }

            if (!this.CopyFiles(sourceHeroDirectory, targetHeroDirectory, "BtlFace_BU.png", "profile-attack.png"))
            {
                Console.Error.WriteLine($"Unable to locate image: [BtlFace_BU.png] for hero: [Name: {hero.Name}, Title: {hero.Title}]");
            }

            if (!this.CopyFiles(sourceHeroDirectory, targetHeroDirectory, "BtlFace_BU_D.png", "profile-injured.png"))
            {
                Console.Error.WriteLine($"Unable to locate image: [BtlFace_BU_D.png] for hero: [Name: {hero.Name}, Title: {hero.Title}]");
            }

            Console.Out.WriteLine("Finished copying art files.");
        }

        private void CopySpriteFiles(Hero hero, bool hasAlternates)
        {
            Console.Out.WriteLine("Copying sprite files...");

            var sourceHeroDirectory = this.GetDirectory("Character Art & Sprites", hero, hasAlternates);

            if (!sourceHeroDirectory.Exists)
            {
                Console.Error.WriteLine($"Unable to locate source directory for hero: [Name: {hero.Name}, Title: {hero.Title}]");
                return;
            }

            var targetPath = Path.Combine(this._targetDirectory, hero.Id.ToString(), "sprite");

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            var targetHeroDirectory = new DirectoryInfo(targetPath);

            if (!this.CopyFiles(sourceHeroDirectory, targetHeroDirectory, "*.ssbp", null))
            {
                Console.Error.WriteLine($"Unable to locate image(s): [*.ssbp] for hero: [Name: {hero.Name}, Title: {hero.Title}]");
            }

            if (!this.CopyFiles(sourceHeroDirectory, targetHeroDirectory, "*Tex*", null))
            {
                Console.Error.WriteLine($"Unable to locate image(s): [*Tex*] for hero: [Name: {hero.Name}, Title: {hero.Title}]");
            }

            this.CopyFiles(sourceHeroDirectory, targetHeroDirectory, "Head_C.png", null);

            Console.Out.WriteLine("Finished copying sprite files.");
        }

        private void CopyEnglishVoiceFiles(Hero hero, bool hasAlternates)
        {
            Console.Out.WriteLine("Copying english voice files...");

            var sourceHeroDirectory = this.GetDirectory("Voices [English]", hero, hasAlternates);

            if (!sourceHeroDirectory.Exists)
            {
                Console.Error.WriteLine($"Unable to locate source directory for hero: [Name: {hero.Name}, Title: {hero.Title}]");
                return;
            }

            var targetPath = Path.Combine(this._targetDirectory, hero.Id.ToString(), "voice");

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            var targetHeroDirectory = new DirectoryInfo(targetPath);

            foreach (var file in sourceHeroDirectory.GetFiles())
            {
                var targetFileName = $"{string.Join("-", Path.GetFileNameWithoutExtension(file.Name).Split('_').TakeLast(2).Select(x => x.ToLower()))}-english.ckb";
                var targetFilePath = Path.Combine(targetHeroDirectory.FullName, targetFileName);

                if (!File.Exists(targetFilePath))
                {
                    File.Copy(file.FullName, targetFilePath);
                }
            }

            Console.Out.WriteLine("Finished copying english voice files.");
        }

        private void CopyJapaneseVoiceFiles(Hero hero, bool hasAlternates)
        {
            Console.Out.WriteLine("Copying japanese voice files...");

            var sourceHeroDirectory = this.GetDirectory("Voices [Japanese]", hero, hasAlternates);

            if (!sourceHeroDirectory.Exists)
            {
                Console.Error.WriteLine($"Unable to locate source directory for hero: [Name: {hero.Name}, Title: {hero.Title}]");
                return;
            }

            var targetPath = Path.Combine(this._targetDirectory, hero.Id.ToString(), "voice");

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            var targetHeroDirectory = new DirectoryInfo(targetPath);

            foreach (var file in sourceHeroDirectory.GetFiles())
            {
                var targetFileName = $"{string.Join("-", Path.GetFileNameWithoutExtension(file.Name).Split('_').TakeLast(2).Select(x => x.ToLower()))}-japanese.ckb";
                var targetFilePath = Path.Combine(targetHeroDirectory.FullName, targetFileName);

                if (!File.Exists(targetFilePath))
                {
                    File.Copy(file.FullName, targetFilePath);
                }
            }

            Console.Out.WriteLine("Finished copying japanese voice files.");
        }

        private DirectoryInfo GetDirectory(string subdirectory, Hero hero, bool hasAlternates)
        {
            var sourcePath = $@"{this._sourceDirectory}\{subdirectory}\{hero.Name}";

            if (hasAlternates)
            {
                sourcePath += $" - {hero.Title}";

                // NOTE(Bryan) - Special check for Tharja.

                if (hero.Title == "\"Normal Girl\"")
                {
                    sourcePath = sourcePath.Replace("\"", "");
                }
            }

            return new DirectoryInfo(sourcePath);
        }

        private bool CopyFiles(DirectoryInfo sourceDirectory, DirectoryInfo targetDirectory, string searchPattern, string fileName)
        {
            var files = sourceDirectory.GetFiles(searchPattern, SearchOption.AllDirectories);

            if (files.Length == 0)
            {
                return false;
            }
            else
            {
                for (var i = 0; i < files.Length; i++)
                {
                    var file = files[i];

                    var targetFilePath = Path.Combine(targetDirectory.FullName, fileName ?? file.Name);

                    if (this._overwrite || !File.Exists(targetFilePath))
                    {
                        File.Copy(file.FullName, targetFilePath, overwrite: this._overwrite);
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
