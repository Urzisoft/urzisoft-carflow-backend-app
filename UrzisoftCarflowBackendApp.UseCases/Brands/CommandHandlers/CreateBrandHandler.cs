using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Brands.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.CommandHandlers
{
    public class CreateBrandHandler : IRequestHandler<CreateBrand, Brand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBrandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Brand> Handle(CreateBrand request, CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                Name = request.Name,
                Description = request.Description,
            };

            await _unitOfWork.BrandRepository.Create(brand);
            await _unitOfWork.Save();

            return brand;
        }
    }
}
