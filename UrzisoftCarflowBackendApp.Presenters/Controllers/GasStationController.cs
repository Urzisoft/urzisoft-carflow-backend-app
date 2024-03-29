﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.GasStationDtos;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/gas-stations")]
    [ApiController]
    [Authorize(Policy = "ActivePolicy")]

    public class GasStationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GasStationController(IMediator mediator, IImageStorageService imageStorageService)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGasStationsEndpoint()
        {
            var query = new GetAllGasStations();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{gasStationId}")]
        public async Task<IActionResult> GetGasStationById(int gasStationId)
        {
            var query = new GetGasStationById
            {
                Id = gasStationId,
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGasStationEndpoint([FromForm] GasStationDto gasStationDto, IFormFile File)
        {
            var command = new CreateGasStation
            {
                File = File,
                Name = gasStationDto.Name,
                FuelId = gasStationDto.FuelId,
                CityId = gasStationDto.CityId,
                Address = gasStationDto.Address,  
                Rank = gasStationDto.Rank,
                ContainerName = AzureContainers.GetCarFlowGasStations(),
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{gasStationId}")]
        public async Task<IActionResult> DeleteGasStation(int gasStationId)
        {
            var command = new DeleteGasStation { 
                GasStationId = gasStationId,
                ContainerName = AzureContainers.GetCarFlowGasStations()
            };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{gasStationId}")]
        public async Task<IActionResult> UpdateGasStation(int gasStationId, [FromForm] GasStationPatchDto gasStationDto, IFormFile File)
        {
            var command = new UpdateGasStation
            {
                Id = gasStationId,
                File = File,
                Name = gasStationDto.Name,
                FuelId = gasStationDto.FuelId,
                CityId = gasStationDto.CityId,
                Address = gasStationDto.Address,
                Rank = gasStationDto.Rank,
                ContainerName = AzureContainers.GetCarFlowGasStations()
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
