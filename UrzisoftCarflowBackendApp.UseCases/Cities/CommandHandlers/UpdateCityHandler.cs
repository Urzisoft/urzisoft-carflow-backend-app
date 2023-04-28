using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cities.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.CommandHandlers
{
    public class UpdateCityHandler : IRequestHandler<UpdateCity, City>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public UpdateCityHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<City> Handle(UpdateCity request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.CityRepository.GetById(request.Id);
            var validateCityName = request.Name ?? city.Name;
            var validateCityCounty = request.County ?? city.County;

            var fileName = validateCityName + "-" + validateCityCounty;
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            if (city is not null)
            {
                city.StorageImageUrl = CustomStorageImageUrl ?? city.StorageImageUrl;
                city.Name = request.Name ?? city.Name;
                city.County = request.County ?? city.County;

                await _unitOfWork.Save();

                return city;
            }

            return null;
        }
    }
}
