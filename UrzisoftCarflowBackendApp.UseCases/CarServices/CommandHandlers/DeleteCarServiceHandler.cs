using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarServices.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.CommandHandlers
{
    public class DeleteCarServiceHandler : IRequestHandler<DeleteCarService, CarService>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public DeleteCarServiceHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<CarService> Handle(DeleteCarService request, CancellationToken cancellationToken)
        {
            var carService = await _unitOfWork.CarServiceRepository.GetById(request.CarServiceId);
            
            if (carService is not null)
            {
                string fileName = carService.Name + "-" + carService.Address;

                await _imageStorageService.DeleteImage(fileName, request.ContainerName);
                await _unitOfWork.CarServiceRepository.Delete(carService);
                await _unitOfWork.Save();

                return carService;
            }

            return null;

        }
    }
}
