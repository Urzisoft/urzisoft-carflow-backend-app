using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Models.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Models.CommandHandlers
{
    public class UpdateModelHandler : IRequestHandler<UpdateModel, Model>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateModelHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Model> Handle(UpdateModel request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.ModelRepository.GetById(request.Id);

            if (model is not null)
            {
                model.Name = request.Name ?? model.Name;

                await _unitOfWork.Save();

                return model;
            }

            return null;
        }
    }
}
