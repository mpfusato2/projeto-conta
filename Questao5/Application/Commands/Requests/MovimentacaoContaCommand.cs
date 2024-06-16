using MediatR;

namespace Questao5.Application.Commands.Requests
{
    public class MovimentacaoContaCommand:IRequest<string>
    {
        public string IdMovimento { get; set; }
        public string IdContaCorrente { get; set; }
        public double Valor { get; set; }
        public string TipoMovimento { get; set; }
    }
}
