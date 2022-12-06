using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FEHub.Api.Options;
using FEHub.Api.Services;
using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Models;
using FEHub.Tests.Benchmarks.Utilities;

using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Options;

namespace FEHub.Tests.Benchmarks.Api.Services;

public class AccessoryServiceBenchmarks
{
    private readonly AccessoryService _efAccessoryService;
    private readonly FEHub.Api.Services.Ado.AccessoryService _adoAccessoryService;

    public AccessoryServiceBenchmarks()
    {
        DatabaseHelpers.Initialize();

        this._efAccessoryService = new AccessoryService(DatabaseHelpers.GetDbContext());

        var databaseOptions = Options.Create(
            new DatabaseOptions() { ConnectionString = DatabaseHelpers.ConnectionString }
        );

        this._adoAccessoryService = new FEHub.Api.Services.Ado.AccessoryService(databaseOptions);
    }

    [Benchmark]
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

    [Benchmark]
    public async Task<Accessory> GetByIdAsync_Ef()
    {
        var accessory = await GetByIdAsync(this._efAccessoryService, new Guid("9282D7FD-3D68-58BD-A83B-7BB51AD62E2B"));
        return accessory;
    }

    [Benchmark]
    public async Task<Accessory> GetByIdAsync_Ado()
    {
        var accessory = await GetByIdAsync(this._adoAccessoryService, new Guid("9282D7FD-3D68-58BD-A83B-7BB51AD62E2B"));
        return accessory;
    }

    private static Task<List<Accessory>> GetAllAsync(IAccessoryService accessoryService) => accessoryService.GetAllAsync();

    private static Task<Accessory> GetByIdAsync(IAccessoryService accessoryService, Guid id) => accessoryService.GetByIdAsync(id);
}
