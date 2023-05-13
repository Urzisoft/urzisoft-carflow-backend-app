using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Fuels.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Fuels.CommandHandlers
{
    public class CreateGasStationHandler : IRequestHandler<CreateFuel, Fuel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateGasStationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Fuel> Handle(CreateFuel request, CancellationToken cancellationToken)
        {
            var fuel = new Fuel
            {
                Name = request.Name,
                Description = request.Description,
                Type = request.Type,
                Quality = request.Quality,
            };

            await _unitOfWork.FuelRepository.Create(fuel);
            await _unitOfWork.Save();

            return fuel;
        }
    }
}
