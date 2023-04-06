using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Brands.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.QueryHandlers
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrands, List<Brand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBrandsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Brand>> Handle(GetAllBrands request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BrandRepository.GetAll();
        }
    }
}
