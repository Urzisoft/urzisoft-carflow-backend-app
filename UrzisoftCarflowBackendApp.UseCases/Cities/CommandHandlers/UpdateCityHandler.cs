using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cities.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.CommandHandlers
{
    public class UpdateCityHandler : IRequestHandler<UpdateCity, City>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<City> Handle(UpdateCity request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.CityRepository.GetById(request.Id);

            if (city is not null)
            {
                city.Name = request.Name ?? city.Name;
                city.County = request.County ?? city.County;

                await _unitOfWork.Save();

                return city;
            }

            return null;
        }
    }
}
