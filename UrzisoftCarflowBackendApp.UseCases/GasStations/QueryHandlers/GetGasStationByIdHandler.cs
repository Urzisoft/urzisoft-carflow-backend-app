using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.QueryHandlers
{
    public class GetGasStationByIdHandler : IRequestHandler<GetGasStationById, GasStation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGasStationByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GasStation> Handle(GetGasStationById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GasStationRepository.GetById(request.Id);
        }
    }
}
