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
    internal class GetAllGasStationsHandler : IRequestHandler<GetAllGasStations, List<GasStation>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGasStationsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GasStation>> Handle(GetAllGasStations request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GasStationRepository.GetAll();
        }

    }
}
