using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Models.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Models.QueryHandlers
{
    public class GetAllModelsHandler : IRequestHandler<GetAllModels, List<Model>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllModelsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Model>> Handle(GetAllModels request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ModelRepository.GetAll();
        }
    }
}
