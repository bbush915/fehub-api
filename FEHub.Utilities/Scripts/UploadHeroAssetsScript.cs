//-----------------------------------------------------------------------------
// <copyright file="UploadHeroAssetsScript.cs">
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
    internal sealed class UploadHeroAssetsScript : BaseScript
    {
        #region Fields
        private readonly string _sourceDirectory;
        private readonly IAmazonS3 _s3Client;
        #endregion

        #region Constructors
        public UploadHeroAssetsScript(string sourceDirectory)
        {
            this._sourceDirectory = sourceDirectory;

            this._s3Client = new AmazonS3Client(RegionEndpoint.USEast1);
        }
        #endregion

        #region Methods
        public override Task RunAsync()
        {
            var fileTransferUtility = new TransferUtility(this._s3Client);

            foreach (var heroDirectory in Directory.GetDirectories(this._sourceDirectory).Select(x => Path.GetFileName(x)))
            {
                fileTransferUtility.Upload(
                    Path.Combine(this._sourceDirectory, heroDirectory, "default.png"), 
                    "fehub-assets",
                    $"images/heroes/{heroDirectory}/default.png"
                );
            }

            return Task.CompletedTask;
        }
        #endregion
    }
}
