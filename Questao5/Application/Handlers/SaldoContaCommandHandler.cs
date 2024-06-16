using MediatR;
using Questao5.Application.Queries.Responses;
using Questao5.Infrastructure.Database.Repository;

namespace Questao5.Application.Commands.Requests
{
    public class SaldoContaCommandHandler:IRequestHandler<SaldoContaCommand, SaldoContaResponse>
    {
        private readonly IMediator _mediator;
        private readonly SaldoContaRepository _repository;
        private readonly MovimentacaoContaRepository _movimentacaoContaRepository;

        public SaldoContaCommandHandler(IMediator mediator, SaldoContaRepository repository, 
            MovimentacaoContaRepository movimentacaoContaRepository)
        {
            _mediator = mediator;
            _repository = repository;
            _movimentacaoContaRepository = movimentacaoContaRepository;
        }

        public async Task<SaldoContaResponse> Handle(SaldoContaCommand request, CancellationToken cancellationToken)
        {

            /* Validando contas correntes cadastradas */
            if (!await _movimentacaoContaRepository.ValidaContaAtiva(request.IdContaCorrente) ||
                !await _movimentacaoContaRepository.ValidaConta(request.IdContaCorrente))
            {
                return new SaldoContaResponse();
            }            

            var SaldoConta = await _repository.RetornaSaldoConta(request);

            var nome = await _repository.BuscaTitular(request.IdContaCorrente);

            return new SaldoContaResponse()
            {
                IdContaCorrente = request.IdContaCorrente,
                Titular = nome,
                DataHoraConsulta = DateTime.Now,
                Valor = SaldoConta
            };
        }
    }
} 