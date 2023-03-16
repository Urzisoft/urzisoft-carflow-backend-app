using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cars.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.QueryHandlers
{
    public class GetCarByIdHandler : IRequestHandler<GetCarById, Car>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Car> Handle(GetCarById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CarRepository.GetById(request.Id);
        }
    }
}
