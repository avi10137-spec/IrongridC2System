using IronApi.Models;

namespace IronApi.Services
{
    public interface IAsestService
    {
        Task<Asset?> GetByIdAsync(int id);

        Task CreateUnitAsync(CreateUnitDto dto);

        Task<Asset?> UpdateAsync(int id, UpdateAssetDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
