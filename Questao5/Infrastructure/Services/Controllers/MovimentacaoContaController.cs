using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Infrastructure.Database.Repository;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacaoContaController : ControllerBase
    {        
        private readonly IMediator _mediator;        

        public MovimentacaoContaController(IMediator mediator)
        {            
            _mediator = mediator;         
        }

        [HttpPost(Name = "PostMovimentacaoContaController")]
        public async Task<IActionResult> Post(MovimentacaoContaCommand command)
        {
           var response = await _mediator.Send(command);

            if (response != null || response != "Movimento Salvo com Sucesso") 
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}