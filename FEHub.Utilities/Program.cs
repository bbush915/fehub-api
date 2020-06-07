//-----------------------------------------------------------------------------
// <copyright file="Program.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity;
using FEHub.Utilities.Scripts;

using McMaster.Extensions.CommandLineUtils;

namespace FEHub.Utilities
{
    internal static class Program
    {
        #region Methods
        public static int Main(string[] args)
        {
            var application = new CommandLineApplication()
            {
                Name = "FEHub.Utilities",
                Description = "A collection of utility scripts for the FEHub application.",
            };

            application.HelpOption("-?|-h|--help");

            var sourcePath = application.Option(
                "-s|--source",
                "The source path.",
                CommandOptionType.SingleValue
            );

            var targetPath = application.Option(
                "-t|--target",
                "The target path.",
                CommandOptionType.SingleValue
            );

            #region Import

            var importAccessories = application.Option(
                "--importAccessories",
                "Import accessory data.",
                CommandOptionType.NoValue
            );

            var importArtists = application.Option(
                "--importArtists",
                "Import artist data.",
                CommandOptionType.NoValue
            );

            var importHeroes = application.Option(
                "--importHeroes",
                "Import hero data.",
                CommandOptionType.NoValue
            );

            var importHeroSkills = application.Option(
                "--importHeroSkills",
                "Import hero skill data.",
                CommandOptionType.NoValue
            );

            var importHeroVoiceActors = application.Option(
                "--importHeroVoiceActors",
                "Import hero voice actor data.",
                CommandOptionType.NoValue
            );

            var importItems = application.Option(
                "--importItems",
                "Import item data.",
                CommandOptionType.NoValue
            );

            var importSkills = application.Option(
                "--importSkills",
                "Import skill data.",
                CommandOptionType.NoValue
            );

            var importVoiceActors = application.Option(
                "--importVoiceActors",
                "Import voice actor data.",
                CommandOptionType.NoValue
            );

            #endregion

            #region Miscellaneous

            var extractHeroAssets = application.Option(
                "--extractHeroAssets",
                "Extract the associated hero assets into a standard format.",
                CommandOptionType.NoValue
            );

            var extractSkillAssets = application.Option(
                "--extractSkillAssets",
                "Extract the associated skill assets into a standard format.",
                CommandOptionType.NoValue
            );

            var splitSkillIcons = application.Option(
                "--splitSkillIcons",
                "Splits the skill icons.",
                CommandOptionType.NoValue
            );

            #endregion

            #region Scrape

            var scrapeAccessories = application.Option(
                "--scrapeAccessories",
                "Scrape accessory data from the wiki.",
                CommandOptionType.NoValue
            );

            var scrapeArtists = application.Option(
                "--scrapeArtists",
                "Scrape artist data from the wiki.",
                CommandOptionType.NoValue
            );

            var scrapeHeroes = application.Option(
                "--scrapeHeroes",
                "Scrape hero data from the wiki.",
                CommandOptionType.NoValue
            );

            var scrapeHeroSkills = application.Option(
                "--scrapeHeroSkills",
                "Scrape hero skill data from the wiki.",
                CommandOptionType.NoValue
            );

            var scrapeItems = application.Option(
                "--scrapeItems",
                "Scrape item data from the wiki.",
                CommandOptionType.NoValue
            );

            var scrapeSacredSealCosts = application.Option(
                 "--scrapeSacredSealCosts",
                 "Scrape sacred seal cost data from the wiki.",
                 CommandOptionType.NoValue
             );

            var scrapeSkills = application.Option(
                "--scrapeSkills",
                "Scrape skill data from the wiki.",
                CommandOptionType.NoValue
            );

            var scrapeVoiceActors = application.Option(
                "--scrapeVoiceActors",
                "Scrape voice actor data from the wiki.",
                CommandOptionType.NoValue
            );

            #endregion

            #region Upload

            var uploadHeroAssets = application.Option(
                "--uploadHeroAssets",
                "Uploads hero assets to AWS S3.",
                CommandOptionType.NoValue
            );

            var uploadSkillAssets = application.Option(
                "--uploadSkillAssets",
                "Uploads skill assets to AWS S3.",
                CommandOptionType.NoValue
            );

            #endregion

            application.OnExecuteAsync(
                async (cancellationToken) =>
                {
                    var dbContextFactory = new FehContextFactory();

                    #region Import

                    if (importAccessories.HasValue())
                    {
                        await new ImportAccessoriesScript(
                            dbContextFactory,
                            sourceFile: sourcePath.Value()
                        ).RunAsync();
                    }

                    if (importArtists.HasValue())
                    {
                        await new ImportArtistsScript(
                            dbContextFactory,
                            sourceFile: sourcePath.Value()
                        ).RunAsync();
                    }

                    if (importHeroes.HasValue())
                    {
                        await new ImportHeroesScript(
                            dbContextFactory,
                            sourceFile: sourcePath.Value()
                        ).RunAsync();
                    }

                    if (importHeroSkills.HasValue())
                    {
                        await new ImportHeroSkillsScript(
                            dbContextFactory,
                            sourceFile: sourcePath.Value()
                        ).RunAsync();
                    }

                    if (importHeroVoiceActors.HasValue())
                    {
                        await new ImportHeroVoiceActorsScript(
                            dbContextFactory,
                            sourceFile: sourcePath.Value()
                        ).RunAsync();
                    }

                    if (importItems.HasValue())
                    {
                        await new ImportItemsScript(
                            dbContextFactory,
                            sourceFile: sourcePath.Value()
                        ).RunAsync();
                    }

                    if (importSkills.HasValue())
                    {
                        await new ImportSkillsScript(
                            dbContextFactory,
                            sourceFile: sourcePath.Value()
                        ).RunAsync();
                    }

                    if (importVoiceActors.HasValue())
                    {
                        await new ImportVoiceActorsScript(
                            dbContextFactory,
                            sourceFile: sourcePath.Value()
                        ).RunAsync();
                    }

                    #endregion

                    #region Miscellaneous

                    if (extractHeroAssets.HasValue())
                    {
                        await new ExtractHeroAssetsScript(
                            dbContextFactory,
                            sourceDirectory: sourcePath.Value(),
                            targetDirectory: targetPath.Value()
                        ).RunAsync();
                    }

                    if (extractSkillAssets.HasValue())
                    {
                        await new ExtractSkillAssetsScript(
                            dbContextFactory,
                            sourceDirectory: sourcePath.Value(),
                            targetDirectory: targetPath.Value()
                        ).RunAsync();
                    }

                    if (splitSkillIcons.HasValue())
                    {
                        await new SplitSkillIconsScript(
                            sourceFile: sourcePath.Value(),
                            targetDirectory: targetPath.Value()
                        ).RunAsync();
                    }

                    #endregion

                    #region Scrape

                    if (scrapeAccessories.HasValue())
                    {
                        await new ScrapeAccessoriesScript(
                            targetDirectory: targetPath.Value()
                        ).RunAsync();
                    }

                    if (scrapeArtists.HasValue())
                    {
                        await new ScrapeArtistsScript(
                            targetDirectory: targetPath.Value()
                        ).RunAsync();
                    }

                    if (scrapeHeroes.HasValue())
                    {
                        await new ScrapeHeroesScript(
                            targetDirectory: targetPath.Value()
                        ).RunAsync();
                    }

                    if (scrapeHeroSkills.HasValue())
                    {
                        await new ScrapeHeroSkillsScript(
                            targetDirectory: targetPath.Value()
                        ).RunAsync();
                    }

                    if (scrapeItems.HasValue())
                    {
                        await new ScrapeItemsScript(
                            targetDirectory: targetPath.Value()
                        ).RunAsync();
                    }

                    if (scrapeSacredSealCosts.HasValue())
                    {
                        await new ScrapeSacredSealCostsScript(
                            targetDirectory: targetPath.Value()
                        ).RunAsync();
                    }

                    if (scrapeSkills.HasValue())
                    {
                        await new ScrapeSkillsScript(
                            targetDirectory: targetPath.Value()
                        ).RunAsync();
                    }

                    if (scrapeVoiceActors.HasValue())
                    {
                        await new ScrapeVoiceActorsScript(
                            targetDirectory: targetPath.Value()
                        ).RunAsync();
                    }

                    #endregion

                    #region Upload

                    if (uploadHeroAssets.HasValue())
                    {
                        await new UploadHeroAssetsScript(
                            sourceDirectory: sourcePath.Value()
                        ).RunAsync();
                    }

                    if (uploadSkillAssets.HasValue())
                    {
                        await new UploadSkillAssetsScript(
                            sourceDirectory: sourcePath.Value()
                        ).RunAsync();
                    }

                    #endregion

                    return 0;
                }
            );

            return application.Execute(args);
        }
        #endregion
    }
}
