using IronApi.Maping;
using IronApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace IronApi.Controllers
{
    [ApiController]
    [Route("api/assets-status")]
    public class AssetsStatusController : ControllerBase
    {
        private readonly IAssetStatusService _assetStatusService;

        public AssetsStatusController(
            IAssetStatusService assetStatusService)
        {
            _assetStatusService = assetStatusService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =
                await _assetStatusService.GetAllAsync();

           
            return Ok(result);
        }


        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var result =
                await _assetStatusService.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


      
        [HttpGet("/{status}")]
        public async Task<IActionResult> GetByStatus( string status)

        {
            if (string.IsNullOrWhiteSpace(status))
                return BadRequest();

            var result =
                await _assetStatusService
                    .GetByStatusAsync(status);

         
            return Ok(result);
        }
    }


}

