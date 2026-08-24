using IronApi.Maping;
using IronApi.Models;
using IronApi.Services;
using Microsoft.EntityFrameworkCore;
using System;




public class AssetService : IAsestService
{
    private readonly IronApiDbContext _context;

    public AssetService(IronApiDbContext context)
    {
        _context = context;
    }



    public async Task<Asset?> GetByIdAsync(int id)
    {
        return await _context.Assets.FirstOrDefaultAsync(a => a.Id == id);

    }



    public async Task CreateUnitAsync(CreateUnitDto dto)
    {
        var unit = new Unit
        {
            UnitName = dto.UnitName,
            Sector = dto.Sector
        };

        _context.Units.Add(unit);

        await _context.SaveChangesAsync();
    }



    public async Task<Asset?> UpdateAsync(int id, UpdateAssetDto dto)


    {
        var asset = await _context.Assets
            .FirstOrDefaultAsync(a => a.Id == id);

        if (asset == null)
            return null;

       
        asset.AssetSerial = dto.AssetSerial;
        asset.AssetType = dto.AssetSerial;
        asset.UnitId = dto.UnitId;

        await _context.SaveChangesAsync();

        return asset;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var asset = await _context.Assets
            .FirstOrDefaultAsync(a => a.Id == id);

        if (asset == null)
            return false;

        _context.Assets.Remove(asset);

        await _context.SaveChangesAsync();

        return true;
    }
}

