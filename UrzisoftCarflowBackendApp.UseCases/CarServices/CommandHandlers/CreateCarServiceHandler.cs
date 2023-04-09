using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarServices.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.CommandHandlers
{
    public class CreateCarServiceHandler : IRequestHandler<CreateCarService, CarService>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateCarServiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarService> Handle(CreateCarService request, CancellationToken cancellationToken)
        {
            var carService = new CarService
            {
                Name = request.Name,
                Description = request.Description,
                Address = request.Address,
                BrandsList = request.BrandsList,      
            };

            await _unitOfWork.CarServiceRepository.Create(carService);
            await _unitOfWork.Save();

            return carService;
        }
    }
}
