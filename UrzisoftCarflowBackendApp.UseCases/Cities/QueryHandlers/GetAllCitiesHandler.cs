using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cities.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.QueryHandlers
{
    public class GetAllCitiesHandler : IRequestHandler<GetAllCities, List<City>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCitiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<City>> Handle(GetAllCities request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CityRepository.GetAll();
        }
    }
}
