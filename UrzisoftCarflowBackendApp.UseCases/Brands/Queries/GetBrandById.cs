using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.Queries
{
    public class GetBrandById : IRequest<Brand>
    {
        public int Id { get; set; }
    }
}
