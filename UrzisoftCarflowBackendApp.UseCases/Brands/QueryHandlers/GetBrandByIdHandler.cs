using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Brands.Queries;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.QueryHandlers
{
    public class GetBrandByIdHandler : IRequestHandler<GetBrandById, Brand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBrandByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Brand> Handle(GetBrandById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BrandRepository.GetById(request.Id);
        }
    }
}
