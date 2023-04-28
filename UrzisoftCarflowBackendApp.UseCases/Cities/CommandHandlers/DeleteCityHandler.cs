using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cities.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.CommandHandlers
{
    public class DeleteCityHandler : IRequestHandler<DeleteCity, City>
    {
        private readonly IUnitOfWork _unitOfWOrk;
        private readonly IImageStorageService _imageStorageService;

        public DeleteCityHandler(IUnitOfWork unitOfWOrk, IImageStorageService imageStorageService)
        {
            _unitOfWOrk = unitOfWOrk;
            _imageStorageService = imageStorageService;
        }

        public async Task<City> Handle(DeleteCity request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWOrk.CityRepository.GetById(request.CityId);
            
            if (city is not null)
            {
                var fileName = AzureBlobFileNameBuilder.GetFileNameBasedOnTwoValues(city.Name, city.County);

                await _imageStorageService.DeleteImage(fileName, request.ContainerName);
                await _unitOfWOrk.CityRepository.Delete(city);
                await _unitOfWOrk.Save();

                return city;
            }

            return null;

        }
    }
}
