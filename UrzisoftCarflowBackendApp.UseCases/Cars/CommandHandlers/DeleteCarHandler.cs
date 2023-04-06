using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cars.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.CommandHandlers
{
    public class DeleteCarHandler : IRequestHandler<DeleteCar, Car>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCarHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Car> Handle(DeleteCar request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.CarRepository.GetById(request.CarId);
            
            if (car is not null)
            {
                await _unitOfWork.CarRepository.Delete(car);
                await _unitOfWork.Save();

                return car;
            }

            return null;

        }
    }
}
