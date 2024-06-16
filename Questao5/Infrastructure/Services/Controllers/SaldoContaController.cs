using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaldoContaController : ControllerBase
    {        
        private readonly IMediator _mediator;

        public SaldoContaController(IMediator mediator)
        {            
            _mediator = mediator;         
        }

        [HttpGet(Name = "GetSaldoContaController")]
        public async Task<IActionResult> Get(SaldoContaCommand command)
        {
           var response = await _mediator.Send(command);

            if (response < 0) 
            {
                return BadRequest("Conta Enviada não é valida");
            }

            return Ok(response);
        }
    }
}