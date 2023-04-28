using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Brands.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.CommandHandlers
{
    public class CreateBrandHandler : IRequestHandler<CreateBrand, Brand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public CreateBrandHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<Brand> Handle(CreateBrand request, CancellationToken cancellationToken)
        {
            var fileName = AzureBlobFileNameBuilder.GetBrandFileName(request.Name);
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            var brand = new Brand
            {
                StorageImageUrl = CustomStorageImageUrl,
                Name = request.Name,
                Description = request.Description,
            };

            await _unitOfWork.BrandRepository.Create(brand);
            await _unitOfWork.Save();

            return brand;
        }
    }
}
