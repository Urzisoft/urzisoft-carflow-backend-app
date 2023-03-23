using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cars.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.CommandHandlers
{
    public class DeleteCarHandler : IRequestHandler<DeleteCar, Car>
    {
        private readonly IUnitOfWork _unitOfWOrk;

        public DeleteCarHandler(IUnitOfWork unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
        }

        public async Task<Car> Handle(DeleteCar request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWOrk.CarRepository.GetById(request.CarId);
            
            if (car is not null)
            {
                await _unitOfWOrk.CarRepository.Delete(car);
                await _unitOfWOrk.Save();

                return car;
            }

            return null;

        }
    }
}
