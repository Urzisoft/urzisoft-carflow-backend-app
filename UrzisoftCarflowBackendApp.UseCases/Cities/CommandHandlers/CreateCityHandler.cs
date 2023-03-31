using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cities.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.CommandHandlers
{
    public class CreateCityHandler : IRequestHandler<CreateCity, City>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateCityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<City> Handle(CreateCity request, CancellationToken cancellationToken)
        {
            var city = new City
            {
                Name = request.Name,
                County = request.County,
            };

            await _unitOfWork.CityRepository.Create(city);
            await _unitOfWork.Save();

            return city;
        }
    }
}
