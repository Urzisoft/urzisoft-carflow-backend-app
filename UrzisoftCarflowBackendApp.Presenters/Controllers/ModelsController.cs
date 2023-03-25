using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.ModelDtos;
using UrzisoftCarflowBackendApp.UseCases.Models.Commands;
using UrzisoftCarflowBackendApp.UseCases.Models.Queries;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/models")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModelsEndpoint()
        {
            var query = new GetAllModels();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{modelId}")]
        public async Task<IActionResult> GetModelById(int modelId)
        {
            var query = new GetModelById
            {
                Id = modelId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateModelEndpoint([FromBody] ModelDto modelDto)
        {
            var command = new CreateModel
            {
                Name = modelDto.Name,
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{modelId}")]
        public async Task<IActionResult> DeleteModel(int modelId)
        {
            var command = new DeleteModel { ModelId = modelId };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{modelId}")]
        public async Task<IActionResult> UpdateCar(int modelId, [FromBody] ModelPatchDto modelDto)
        {
            var command = new UpdateModel
            {
                Id = modelId,
                Name = modelDto.Name,
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
