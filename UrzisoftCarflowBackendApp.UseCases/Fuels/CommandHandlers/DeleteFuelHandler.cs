using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Fuels.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Fuels.CommandHandlers
{
    public class DeleteFuelHandler : IRequestHandler<DeleteFuel, Fuel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFuelHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Fuel> Handle(DeleteFuel request, CancellationToken cancellationToken)
        {
            var fuel = await _unitOfWork.FuelRepository.GetById(request.FuelId);

            if (fuel is not null)
            {
                await _unitOfWork.FuelRepository.Delete(fuel);
                await _unitOfWork.Save();

                return fuel;
            }

            return null;
        }
    }
}
