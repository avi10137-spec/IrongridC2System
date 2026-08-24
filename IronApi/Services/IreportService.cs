using IronApi.Models;

namespace IronApi.Services;
public interface IReportsService
{
    Task<List<CriticalAssetDto>>
        GetCriticalAssetsAsync();

    Task<List<UnitAssetDto>>
        GetAssetsByUnitAsync(int unitId);

    Task<List<UnitSummaryDto>>
        GetSummaryByUnitAsync();
}
