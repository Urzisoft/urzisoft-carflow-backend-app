using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarServices.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.QueryHandlers
{
    public class GetCarServiceByIdHandler : IRequestHandler<GetCarServiceById, CarService>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarServiceByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarService> Handle(GetCarServiceById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CarServiceRepository.GetById(request.Id);
        }
    }
}
