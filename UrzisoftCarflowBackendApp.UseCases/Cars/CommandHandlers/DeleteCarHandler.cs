﻿using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cars.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.CommandHandlers
{
    public class DeleteCarHandler : IRequestHandler<DeleteCar, Car>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public DeleteCarHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<Car> Handle(DeleteCar request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.CarRepository.GetById(request.CarId);
            var brand = await _unitOfWork.BrandRepository.GetById(car.BrandId);
            var model = await _unitOfWork.ModelRepository.GetById(car.ModelId);

            if (car is not null)
            {
                var fileName = AzureBlobFileNameBuilder.GetFileNameBasedOnThreeValues(brand.Name, model.Name, car.LicensePlate);

                await _imageStorageService.DeleteImage(fileName, request.ContainerName);
                await _unitOfWork.CarRepository.Delete(car);
                await _unitOfWork.Save();

                return car;
            }

            return null;

        }
    }
}
