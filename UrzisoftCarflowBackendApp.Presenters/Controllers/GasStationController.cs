﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Azure;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.GasStationDtos;
using UrzisoftCarflowBackendApp.Presenters.Dtos.ModelDtos;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Queries;
using UrzisoftCarflowBackendApp.UseCases.Models.Commands;
using UrzisoftCarflowBackendApp.UseCases.Models.Queries;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/gas-stations")]
    [ApiController]
    public class GasStationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GasStationController(IMediator mediator)
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
        public async Task<IActionResult> CreateGasStationEndpoint([FromBody] GasStationDto gasStationDto)
        {
            var command = new CreateGasStation
            {
                Fuel = gasStationDto.Fuel,
                City = gasStationDto.City


            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{gasStationId}")]
        public async Task<IActionResult> DeleteGasStation(int gasStationId)
        {
            var command = new DeleteGasStation { GasStationId = gasStationId };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{gasStationId}")]
        public async Task<IActionResult> UpdateGasStation(int gasStationId, [FromBody] GasStationPatchDto gasStationDto)
        {
            var command = new UpdateGasStation
            {
                Id = gasStationId,
                Fuel = gasStationDto.Fuel,
                City = gasStationDto.City
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
