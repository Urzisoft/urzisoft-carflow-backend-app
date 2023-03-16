using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cars.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.QueryHandlers
{
    internal class GetAllCarsHandler : IRequestHandler<GetAllCars, List<Car>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Car>> Handle(GetAllCars request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CarRepository.GetAll();
        }
    }
}
