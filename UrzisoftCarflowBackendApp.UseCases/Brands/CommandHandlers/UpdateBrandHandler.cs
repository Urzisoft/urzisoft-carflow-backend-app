using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Brands.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.CommandHandlers
{
    public class UpdateBrandHandler : IRequestHandler<UpdateBrand, Brand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public UpdateBrandHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<Brand> Handle(UpdateBrand request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.BrandRepository.GetById(request.Id);
            var fileName = AzureBlobFileNameBuilder.GetFileNameBasedOnValue(request.Name ?? brand.Name);
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            if (brand is not null)
            {
                brand.StorageImageUrl = CustomStorageImageUrl ?? brand.StorageImageUrl; 
                brand.Name = request.Name ?? brand.Name;
                brand.Description = request.Description ?? brand.Description;

                await _unitOfWork.Save();

                return brand;
            }

            return null;
        }
    }
}
