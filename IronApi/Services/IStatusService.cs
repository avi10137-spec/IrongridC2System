using IronApi.Models;

public interface IAssetStatusService
{
    Task<List<AssetStatusDto>> GetAllAsync();

    Task<AssetStatusDto?> GetByIdAsync(int id);

    Task<List<AssetStatusDto>> GetByStatusAsync(string status);

}

