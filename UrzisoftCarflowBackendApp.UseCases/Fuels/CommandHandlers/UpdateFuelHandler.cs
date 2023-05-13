using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Fuels.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Fuels.CommandHandlers
{
    public class UpdateFuelHandler : IRequestHandler<UpdateFuel, Fuel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFuelHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Fuel> Handle(UpdateFuel request, CancellationToken cancellationToken)
        {
            var fuel = await _unitOfWork.FuelRepository.GetById(request.Id);

            if (fuel is not null) 
            {
                fuel.Name = request.Name ?? fuel.Name;
                fuel.Description = request.Description ?? fuel.Description;
                fuel.Type = request.Type ?? fuel.Type;
                fuel.Quality = request.Quality ?? fuel.Quality;

                await _unitOfWork.Save();

                return fuel;
            }

            return null;
        }
    }
}
