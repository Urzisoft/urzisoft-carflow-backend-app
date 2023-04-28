﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.BrandDtos;
using UrzisoftCarflowBackendApp.UseCases.Brands.Commands;
using UrzisoftCarflowBackendApp.UseCases.Brands.Queries;
using UrzisoftCarflowBackendApp.UseCases.Utils;

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
        public async Task<IActionResult> CreateBrandEndpoint([FromForm] BrandDto brandDto, IFormFile File)
        {
            var command = new CreateBrand
            {
                File = File,
                Name = brandDto.Name,
                Description = brandDto.Description,
                ContainerName = AzureContainers.GetCarFlowBrandsContainer()
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{brandId}")]
        public async Task<IActionResult> DeleteBrand(int brandId)
        {
            var command = new DeleteBrand{ 
                BrandId = brandId,
                ContainerName = AzureContainers.GetCarFlowBrandsContainer()
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{brandId}")]
        public async Task<IActionResult> UpdateCar(int brandId, [FromForm] BrandPatchDto brandDto, IFormFile File)
        {
            var command = new UpdateBrand
            {
                Id = brandId,
                File = File,
                Name = brandDto.Name,
                Description = brandDto.Description,
                ContainerName = AzureContainers.GetCarFlowBrandsContainer()
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
