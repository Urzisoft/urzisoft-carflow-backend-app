using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarServices.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.CommandHandlers
{
    public class DeleteCarServiceHandler : IRequestHandler<DeleteCarService, CarService>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCarServiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarService> Handle(DeleteCarService request, CancellationToken cancellationToken)
        {
            var carService = await _unitOfWork.CarServiceRepository.GetById(request.CarServiceId);

            if (carService is not null)
            {
                await _unitOfWork.CarServiceRepository.Delete(carService);
                await _unitOfWork.Save();

                return carService;
            }

            return null;

        }
    }
}
