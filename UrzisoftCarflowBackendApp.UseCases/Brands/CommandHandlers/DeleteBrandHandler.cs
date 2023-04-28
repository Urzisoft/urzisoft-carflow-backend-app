using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Brands.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.CommandHandlers
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrand, Brand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public DeleteBrandHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<Brand> Handle(DeleteBrand request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.BrandRepository.GetById(request.BrandId);

            if (brand is not null)
            {
                string fileName = AzureBlobFileNameBuilder.GetFileNameBasedOnValue(brand.Name);

                await _imageStorageService.DeleteImage(fileName, request.ContainerName);
                await _unitOfWork.BrandRepository.Delete(brand);
                await _unitOfWork.Save();

                return brand;
            }

            return null;

        }
    }
}
