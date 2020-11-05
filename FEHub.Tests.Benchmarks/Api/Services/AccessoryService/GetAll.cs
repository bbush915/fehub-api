//-----------------------------------------------------------------------------
// <copyright file="GetAll.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

using FEHub.Api.Options;
using FEHub.Api.Services;
using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Models;
using FEHub.Tests.Benchmarks.Utilities;

using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Options;

namespace FEHub.Tests.Benchmarks.Api.Services
{
    public class GetAll
    {
        private readonly AccessoryService _efAccessoryService;
        private readonly FEHub.Api.Services.Ado.AccessoryService _adoAccessoryService;

        public GetAll()
        {
            DatabaseHelpers.Initialize();

            this._efAccessoryService = new AccessoryService(DatabaseHelpers.GetDbContext());

            var databaseOptions = Options.Create(
                new DatabaseOptions() { ConnectionString = DatabaseHelpers.ConnectionString }
            );

            this._adoAccessoryService = new FEHub.Api.Services.Ado.AccessoryService(databaseOptions);
        }

        [Benchmark(Baseline = true)]
        public async Task<List<Accessory>> GetAllAsync_Ef()
        {
            var accessories = await GetAllAsync(this._efAccessoryService);
            return accessories;
        }

        [Benchmark]
        public async Task<List<Accessory>> GetAllAsync_Ado()
        {
            var accessories = await GetAllAsync(this._adoAccessoryService);
            return accessories;
        }

        private static Task<List<Accessory>> GetAllAsync(IAccessoryService accessoryService) => accessoryService.GetAllAsync();
    }
}
