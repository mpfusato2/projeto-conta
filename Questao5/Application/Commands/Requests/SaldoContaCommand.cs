using MediatR;

namespace Questao5.Application.Commands.Requests
{
    public class SaldoContaCommand:IRequest<double>
    {
        public string IdContaCorrente { get; set; }     
    }
}
