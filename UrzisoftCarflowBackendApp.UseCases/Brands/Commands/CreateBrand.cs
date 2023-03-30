using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.Commands
{
    public class CreateBrand : IRequest<Brand>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
