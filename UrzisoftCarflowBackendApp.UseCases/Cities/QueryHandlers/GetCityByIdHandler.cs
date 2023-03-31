using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cities.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.QueryHandlers
{
    public class GetCityByIdHandler : IRequestHandler<GetCityById, City>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCityByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<City> Handle(GetCityById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CityRepository.GetById(request.Id);
        }
    }
}
