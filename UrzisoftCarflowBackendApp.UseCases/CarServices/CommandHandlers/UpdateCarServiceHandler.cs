using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarServices.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.CommandHandlers
{
    public class UpdateCarServiceHandler : IRequestHandler<UpdateCarService, CarService>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCarServiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarService> Handle(UpdateCarService request, CancellationToken cancellationToken)
        {
            var carService = await _unitOfWork.CarServiceRepository.GetById(request.Id);

            if (carService is not null)
            {
                carService.Name = request.Name ?? carService.Name;
                carService.Address = request.Address ?? carService.Address;
                carService.Description = request.Description ?? carService.Description;
                carService.BrandsList = request.BrandsList ?? carService.BrandsList;

                await _unitOfWork.Save();
                return carService;
            }

            return null;
        }
    }
}
