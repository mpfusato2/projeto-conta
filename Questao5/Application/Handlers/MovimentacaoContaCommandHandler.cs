using MediatR;
using Questao5.Infrastructure.Database.Repository;

namespace Questao5.Application.Commands.Requests
{
    public class MovimentacaoContaCommandHandler:IRequestHandler<MovimentacaoContaCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly MovimentacaoContaRepository _repository;

        public MovimentacaoContaCommandHandler(IMediator mediator, MovimentacaoContaRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(MovimentacaoContaCommand request, CancellationToken cancellationToken)
        {
            
            /* Validando contas correntes cadastradas */
            if (!await _repository.ValidaConta(request.IdContaCorrente)) 
            {
                return  await Task.FromResult("Conta Corrente não cadastrada");
            }

            /* Validando contas correntes cadastradas e ativas */
            if (!await _repository.ValidaContaAtiva(request.IdContaCorrente))
            {
                return await Task.FromResult("Conta Corrente cadastrada não esta ativa");
            }

            /* Validando valores negativos */
            if (request.Valor < 0)
            {
                return await Task.FromResult("Somente valores maiores que zero são aceitos");
            }

            /* Validando tipos de contas */
            if (request.TipoMovimento != "c" && request.TipoMovimento != "C" &&
                request.TipoMovimento != "d" && request.TipoMovimento != "D")
            {
                return await Task.FromResult("Tipo de movimento inconsistente");
            }

            await _repository.GravaMovimento(request);

            return await Task.FromResult("Movimento Salvo com Sucesso");           

        }
    }
} 