using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.BrandDtos;
using UrzisoftCarflowBackendApp.UseCases.Brands.Commands;
using UrzisoftCarflowBackendApp.UseCases.Brands.Queries;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/brands")]
    [ApiController]
    [Authorize(Policy = "ActivePolicy")]

    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrandsEndpoint()
        {
            var query = new GetAllBrands();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{brandId}")]
        public async Task<IActionResult> GetBrandById(int brandId)
        {
            var query = new GetBrandById
            {
                Id = brandId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrandEndpoint([FromBody] BrandDto brandDto)
        {
            var command = new CreateBrand
            {
                Name = brandDto.Name,
                Description = brandDto.Description,
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{brandId}")]
        public async Task<IActionResult> DeleteBrand(int brandId)
        {
            var command = new DeleteBrand{ BrandId = brandId };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{brandId}")]
        public async Task<IActionResult> UpdateCar(int brandId, [FromBody] BrandPatchDto brandDto)
        {
            var command = new UpdateBrand
            {
                Id = brandId,
                Name = brandDto.Name,
                Description = brandDto.Description,
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
