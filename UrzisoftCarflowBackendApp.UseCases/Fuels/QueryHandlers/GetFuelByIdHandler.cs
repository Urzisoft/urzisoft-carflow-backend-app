using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Fuels.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Fuels.QueryHandlers
{
    public class GetFuelByIdHandler : IRequestHandler<GetFuelById, Fuel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFuelByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Fuel> Handle(GetFuelById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.FuelRepository.GetById(request.Id);
        }
    }
}
