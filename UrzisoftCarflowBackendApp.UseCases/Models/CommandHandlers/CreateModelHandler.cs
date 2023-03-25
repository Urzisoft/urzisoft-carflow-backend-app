using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Models.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Models.CommandHandlers
{
    public class CreateModelHandler : IRequestHandler<CreateModel, Model>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateModelHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Model> Handle(CreateModel request, CancellationToken cancellationToken)
        {
            var model = new Model
            {
                Name = request.Name,
            };

            await _unitOfWork.ModelRepository.Create(model);
            await _unitOfWork.Save();

            return model;
        }
    }
}
