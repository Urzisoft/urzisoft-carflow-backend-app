using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Models.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Models.CommandHandlers
{
    public class DeleteModelHandler : IRequestHandler<DeleteModel, Model>
    {
        private readonly IUnitOfWork _unitOfWOrk;

        public DeleteModelHandler(IUnitOfWork unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
        }

        public async Task<Model> Handle(DeleteModel request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWOrk.ModelRepository.GetById(request.ModelId);

            if (model is not null)
            {
                await _unitOfWOrk.ModelRepository.Delete(model);
                await _unitOfWOrk.Save();

                return model;
            }

            return null;

        }
    }
}
