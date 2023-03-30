using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Brands.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.CommandHandlers
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrand, Brand>
    {
        private readonly IUnitOfWork _unitOfWOrk;

        public DeleteBrandHandler(IUnitOfWork unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
        }

        public async Task<Brand> Handle(DeleteBrand request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWOrk.BrandRepository.GetById(request.BrandId);

            if (brand is not null)
            {
                await _unitOfWOrk.BrandRepository.Delete(brand);
                await _unitOfWOrk.Save();

                return brand;
            }

            return null;

        }
    }
}
