using IronApi.Maping;
using IronApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace IronApi.Services
{

    public class ReportsService : IReportsService
    {
        private readonly IronApiDbContext _context;

        public ReportsService(IronApiDbContext context)
        {
            _context = context;
        }


        
        public async Task<List<CriticalAssetDto>>
            GetCriticalAssetsAsync()
        {
            var result = await (
                from asset in _context.Assets

                join status in _context.AssetLiveStatus
                    on asset.Id equals status.AssetId

                join unit in _context.Units
                    on asset.UnitId equals unit.Id

                where status.ProcessedStatus == "Warning"
                   || status.IsVerified == false

                select new CriticalAssetDto
                {
                    Id = asset.Id,
                    AssetSerial = asset.AssetSerial,
                    AssetType = asset.AssetType,
                    

                    UnitName = unit.UnitName,
                    Sector = unit.Sector,

                    ProcessedStatus = status.ProcessedStatus,
                    IsVerified = status.IsVerified,
                    LastUpdate = status.LastUpdate
                }).ToListAsync();


            return result;
        }


        public async Task<List<UnitAssetDto>>
            GetAssetsByUnitAsync(int unitId)
        {
            var result = await (
                from asset in _context.Assets

                join status in _context.AssetLiveStatus
                    on asset.Id equals status.AssetId

                where asset.UnitId == unitId

                select new UnitAssetDto
                {
                    Id = asset.Id,
                    AssetSerial = asset.AssetSerial,
                    AssetType = asset.AssetType,

                    ProcessedStatus = status.ProcessedStatus,
                    IsVerified = status.IsVerified,
                    LastUpdate = status.LastUpdate
                }
            ).ToListAsync();

            return result;
        }


     
        public async Task<List<UnitSummaryDto>>
            GetSummaryByUnitAsync()
        {
            var result = await (
                from unit in _context.Units

                join asset in _context.Assets
                    on unit.Id equals asset.UnitId

                join status in _context.AssetLiveStatus
                    on asset.Id equals status.AssetId

                group new
                {
                    asset,
                    status
                }
                by new
                {
                    unit.Id,
                    unit.UnitName,
                    unit.Sector
                }
                into grouped

                select new UnitSummaryDto
                {
                    Id = grouped.Key.Id,
                    UnitName = grouped.Key.UnitName,
                    Sector = grouped.Key.Sector,

                    TotalAssets = grouped.Count(),

                    StableAssets = grouped.Count(x =>
                        x.status.ProcessedStatus == "Stable"),

                    WarningAssets = grouped.Count(x =>
                        x.status.ProcessedStatus == "Warning"),

                    UnverifiedAssets = grouped.Count(x =>
                        x.status.IsVerified == false)
                }
            ).ToListAsync();

            return result;
        }
    }
}


