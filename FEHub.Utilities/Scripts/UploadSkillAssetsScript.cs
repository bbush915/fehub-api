//-----------------------------------------------------------------------------
// <copyright file="UploadSkillAssetsScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.IO;
using System.Linq;
using System.Threading.Tasks;

using FEHub.Utilities.Scripts.Base;

using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace FEHub.Utilities.Scripts
{
    internal sealed class UploadSkillAssetsScript : BaseScript
    {
        private readonly string _sourceDirectory;

        private readonly IAmazonS3 _s3Client;

        public UploadSkillAssetsScript(string sourceDirectory)
        {
            this._sourceDirectory = sourceDirectory;

            this._s3Client = new AmazonS3Client(RegionEndpoint.USEast1);
        }

        public override Task RunAsync()
        {
            var fileTransferUtility = new TransferUtility(this._s3Client);

            foreach (var skillDirectory in Directory.GetDirectories(this._sourceDirectory).Select(x => Path.GetFileName(x)))
            {
                var filePath = Path.Combine(this._sourceDirectory, skillDirectory, "icon.png");
                
                if (!File.Exists(filePath))
                {
                    continue;
                }

                fileTransferUtility.Upload(
                    filePath,
                    "fehub-assets",
                    $"images/skills/{skillDirectory}/icon.png"
                );
            }

            return Task.CompletedTask;
        }
    }
}
