using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Brands.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.CommandHandlers
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrand, Brand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBrandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Brand> Handle(DeleteBrand request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.BrandRepository.GetById(request.BrandId);

            if (brand is not null)
            {
                await _unitOfWork.BrandRepository.Delete(brand);
                await _unitOfWork.Save();

                return brand;
            }

            return null;

        }
    }
}
