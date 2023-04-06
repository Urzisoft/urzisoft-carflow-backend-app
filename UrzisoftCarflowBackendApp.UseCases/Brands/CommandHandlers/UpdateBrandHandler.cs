using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Brands.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.CommandHandlers
{
    public class UpdateBrandHandler : IRequestHandler<UpdateBrand, Brand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBrandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Brand> Handle(UpdateBrand request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.BrandRepository.GetById(request.Id);

            if (brand is not null)
            {
                brand.Name = request.Name ?? brand.Name;
                brand.Description = request.Description ?? brand.Description;

                await _unitOfWork.Save();

                return brand;
            }

            return null;
        }
    }
}
