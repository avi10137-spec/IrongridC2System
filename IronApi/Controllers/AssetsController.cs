using IronApi.Maping;
using IronApi.Models;
using IronApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace IronApi.Controllers
{
    [ApiController]

    [Route("api/assets")]
    public class AssetsController : ControllerBase
    {
        private readonly IAsestService _assetService;

        public AssetsController(IAsestService assetService)
        {
            _assetService = assetService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var asset = await _assetService.GetByIdAsync(id);

            if (asset == null)
                return NotFound();

            return Ok(asset);
        }


  
        [HttpPost("units")]
        public async Task<IActionResult> CreateUnit(
            [FromBody] CreateUnitDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _assetService.CreateUnitAsync(dto);

          
            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateAssetDto dto)
        {
            if (id <= 0)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var asset =
                await _assetService.UpdateAsync(id, dto);

            if (asset == null)
                return NotFound();

           
            return Ok(asset);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var deleted =
                await _assetService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

           
            return NoContent();
        }
    }
}

