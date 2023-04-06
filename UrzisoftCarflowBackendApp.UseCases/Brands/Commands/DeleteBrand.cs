using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.Commands
{
    public class DeleteBrand : IRequest<Brand>
    {
        public int BrandId { get; set; }
    }
}
