using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.ModelDtos;
using UrzisoftCarflowBackendApp.Presenters.Dtos.PriceDto;
using UrzisoftCarflowBackendApp.UseCases.Models.Commands;
using UrzisoftCarflowBackendApp.UseCases.Prices.Commands;
using UrzisoftCarflowBackendApp.UseCases.Prices.Queries;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/[prices]")]
    [ApiController]
    [Authorize(Policy = "ActivePolicy")]
    public class PricesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPricesEndpoint()
        {
            var query = new GetAllPrices();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{priceId}")]
        public async Task<IActionResult> GetPriceById(int priceId)
        {
            var query = new GetPriceById
            {
                Id = priceId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePriceEndpoint([FromBody] PriceDto priceDto)
        {
            var command = new CreatePrice
            {
                Value = priceDto.Value,
                Fuel = priceDto.Fuel,
                Date = priceDto.Date,
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{priceId}")]
        public async Task<IActionResult> DeletePrice(int priceId)
        {
            var command = new DeletePrice { PriceId = priceId };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{modelId}")]
        public async Task<IActionResult> UpdatePrice(int priceId, [FromBody] PricePatchDto priceDto)
        {
            var command = new UpdatePrice
            {
                Id = priceId,
                Value = priceDto.Value,
                Fuel = priceDto.Fuel,
                Date = priceDto.Date
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
