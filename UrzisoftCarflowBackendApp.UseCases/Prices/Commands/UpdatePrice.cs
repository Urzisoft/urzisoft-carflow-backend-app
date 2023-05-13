using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Prices.Commands
{
    public class UpdatePrice : IRequest<Price>
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Fuel { get; set; }
        public string Date { get; set; }
    }
}
