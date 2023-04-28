using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cities.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.CommandHandlers
{
    public class CreateCityHandler : IRequestHandler<CreateCity, City>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public CreateCityHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<City> Handle(CreateCity request, CancellationToken cancellationToken)
        {
            var fileName = request.Name + "-" + request.County;
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            var city = new City
            {
                StorageImageUrl = CustomStorageImageUrl,
                Name = request.Name,
                County = request.County,
            };

            await _unitOfWork.CityRepository.Create(city);
            await _unitOfWork.Save();

            return city;
        }
    }
}
