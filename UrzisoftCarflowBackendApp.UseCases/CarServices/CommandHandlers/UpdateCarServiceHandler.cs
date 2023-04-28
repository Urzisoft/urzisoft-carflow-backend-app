using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarServices.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.CommandHandlers
{
    public class UpdateCarServiceHandler : IRequestHandler<UpdateCarService, CarService>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public UpdateCarServiceHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<CarService> Handle(UpdateCarService request, CancellationToken cancellationToken)
        {
            var carService = await _unitOfWork.CarServiceRepository.GetById(request.Id);
            var validName = request.Name ?? carService.Name;
            var validAddress = request.Address ?? carService.Address;
            var fileName = AzureBlobFileNameBuilder.GetFileNameBasedOnTwoValues(validName, validAddress);
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            if (carService is not null)
            {
                carService.StorageImageUrl = CustomStorageImageUrl ?? carService.StorageImageUrl;   
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
