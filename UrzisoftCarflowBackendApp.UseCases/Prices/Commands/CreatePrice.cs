using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Prices.Commands
{
    public class CreatePrice : IRequest<Price>
    {
        public int Value { get; set; }
        public string Fuel { get; set; }
        public string Date { get; set; }
    }
}
