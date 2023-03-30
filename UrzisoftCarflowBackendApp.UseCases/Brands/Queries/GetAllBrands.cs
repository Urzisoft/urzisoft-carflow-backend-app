using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.Queries
{
    public class GetAllBrands : IRequest<List<Brand>>
    {
    }
}
