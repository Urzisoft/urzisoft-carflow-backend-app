using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Prices.Commands
{
    public class CreatePrice : IRequest<Price>
    {
        public double Value { get; set; }
        public string Fuel { get; set; }
        public string Date { get; set; }
    }
}
