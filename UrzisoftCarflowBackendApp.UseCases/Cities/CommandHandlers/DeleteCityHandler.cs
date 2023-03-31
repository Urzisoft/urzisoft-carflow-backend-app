using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cities.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.CommandHandlers
{
    public class DeleteCityHandler : IRequestHandler<DeleteCity, City>
    {
        private readonly IUnitOfWork _unitOfWOrk;

        public DeleteCityHandler(IUnitOfWork unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
        }

        public async Task<City> Handle(DeleteCity request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWOrk.CityRepository.GetById(request.CityId);
            
            if (city is not null)
            {
                await _unitOfWOrk.CityRepository.Delete(city);
                await _unitOfWOrk.Save();

                return city;
            }

            return null;

        }
    }
}
