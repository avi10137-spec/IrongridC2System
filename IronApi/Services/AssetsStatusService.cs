using IronApi.Maping;
using IronApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace IronApi.Services
{
    public class AssetsStatusService : IAssetStatusService
    {
        private readonly IronApiDbContext _context;

        public AssetsStatusService(IronApiDbContext context)
        {
            _context = context;
        }


        public async Task<List<AssetStatusDto>> GetAllAsync()
        {
            var result = await (
                from asset in _context.Assets

                join status in _context.AssetLiveStatus
                    on asset.Id equals status.AssetId

                select new AssetStatusDto
                {
                    AssetId = asset.Id,
                    AssetSerial = asset.AssetSerial,
                    AssetType = asset.AssetType,


                    ProcessedStatus = status.ProcessedStatus,
                    IsVerified = status.IsVerified,
                    LastUpdate = status.LastUpdate
                }).ToListAsync();
         

            return result;
        }


       
        public async Task<AssetStatusDto?> GetByIdAsync(int id)
        {
            var result = await (
                from asset in _context.Assets

                join status in _context.AssetLiveStatus
                    on asset.Id equals status.AssetId

                where asset.Id == id

                select new AssetStatusDto
                {
                    AssetId = asset.Id,
                    AssetSerial = asset.AssetSerial,
                    AssetType = asset.AssetType,
                   

                    ProcessedStatus = status.ProcessedStatus,
                    IsVerified = status.IsVerified,
                    LastUpdate = status.LastUpdate
                }
            ).FirstOrDefaultAsync();

            return result;
        }


        
        public async Task<List<AssetStatusDto>> GetByStatusAsync(
            string status)
        {
            var result = await (
                from asset in _context.Assets

                join assetStatus in _context.AssetLiveStatus
                    on asset.Id equals assetStatus.AssetId

                where assetStatus.ProcessedStatus == status

                select new AssetStatusDto
                {
                    AssetId = asset.Id,
                    AssetSerial = asset.AssetSerial,
                    AssetType = asset.AssetType,
                 

                    ProcessedStatus = assetStatus.ProcessedStatus,
                    IsVerified = assetStatus.IsVerified,
                    LastUpdate = assetStatus.LastUpdate
                }
            ).ToListAsync();

            return result;
        }
    }
}

