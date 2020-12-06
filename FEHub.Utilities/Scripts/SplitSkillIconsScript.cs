//-----------------------------------------------------------------------------
// <copyright file="SplitSkillIconsScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

using FEHub.Utilities.Scripts.Base;


namespace FEHub.Utilities.Scripts
{
    internal sealed class SplitSkillIconsScript : BaseScript
    {
        private const int ICON_WIDTH = 76;
        private const int ICON_HEIGHT = 76;

        private readonly string _sourceFile;
        private readonly string _targetDirectory;

        public SplitSkillIconsScript(string sourceFile, string targetDirectory)
        {
            this._sourceFile = sourceFile;
            this._targetDirectory = targetDirectory;
        }

        public override Task RunAsync()
        {
            var source = (Bitmap)Image.FromFile(this._sourceFile);

            var widthCount = source.Width / ICON_WIDTH;
            var heightCount = source.Height / ICON_HEIGHT;

            for (var i = 0; i < widthCount; ++i)
            {
                for (var j = 0; j < heightCount; ++j)
                {
                    using var icon = source.Clone(
                        new Rectangle(i * ICON_WIDTH, j * ICON_HEIGHT, ICON_WIDTH, ICON_HEIGHT),
                        source.PixelFormat
                    );

                    icon.Save(Path.Combine(this._targetDirectory, $"{j + 1}.{i + 1}.png"));
                }
            }

            return Task.CompletedTask;
        }
    }
}
