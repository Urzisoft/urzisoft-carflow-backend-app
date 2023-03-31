using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Models.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Models.QueryHandlers
{
    public class GetModelByIdHandler : IRequestHandler<GetModelById, Model>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetModelByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Model> Handle(GetModelById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ModelRepository.GetById(request.Id);
        }
    }
}
