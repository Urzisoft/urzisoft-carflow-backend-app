using MediatR;
using Microsoft.AspNetCore.Http;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Brands.Commands
{
    public class UpdateBrand : IRequest<Brand>
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
        public string ContainerName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
