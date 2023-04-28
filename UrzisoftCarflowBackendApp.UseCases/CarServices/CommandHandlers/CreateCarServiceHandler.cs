using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarServices.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.CommandHandlers
{
    public class CreateCarServiceHandler : IRequestHandler<CreateCarService, CarService>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public CreateCarServiceHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<CarService> Handle(CreateCarService request, CancellationToken cancellationToken)
        {
            string fileName = request.Name + "-" + request.Address;
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            var carService = new CarService
            {
                StorageImageUrl = CustomStorageImageUrl,    
                Name = request.Name,
                Description = request.Description,
                Address = request.Address,
                BrandsList = request.BrandsList,      
            };

            await _unitOfWork.CarServiceRepository.Create(carService);
            await _unitOfWork.Save();

            return carService;
        }
    }
}
