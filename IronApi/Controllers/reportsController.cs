using IronApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IronApi.Controllers
{
   
        [ApiController]
        [Route("api/reports")]
        public class OperationsReportsController : ControllerBase
        {
            private readonly IReportsService _reportsService;

            public OperationsReportsController(
                IReportsService reportsService)
            {
                _reportsService = reportsService;
            }


          
            [HttpGet("critical-assets")]
            public async Task<IActionResult> GetCriticalAssets()
            {
                var result =
                    await _reportsService
                        .GetCriticalAssetsAsync();

              
                return Ok(result);
            }


           
            [HttpGet("unit/{unitId}/assets")]
            public async Task<IActionResult> GetAssetsByUnit(
                int unitId)
            {
                if (unitId <= 0)
                    return BadRequest();

                var result =
                    await _reportsService
                        .GetAssetsByUnitAsync(unitId);

                

                if (result == null)
                    return NotFound();

               
                return Ok(result);
            }


         
            [HttpGet("summary-by-unit")]
            public async Task<IActionResult> GetSummaryByUnit()
            {
                var result =
                    await _reportsService
                        .GetSummaryByUnitAsync();

              
                return Ok(result);
            }
        }
    }

