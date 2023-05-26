using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Acontecimientos.Commands.CreateAcontecimientos;
using WebApiTest.Application.Features.Acontecimientos.Dto;
using WebApiTest.Application.Features.Clientes.Commands.CreateClientes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientesController : ApiControllerBase
    {
        [HttpPost("GenerarCliente")]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(typeof(ResponseType<AcontecimientosResponseType>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCliente([FromBody] CreateClientesRequest request, CancellationToken cancellationToken)
        {
            var objResult = await Mediator.Send(new CreateClientesCommand(request), cancellationToken);
            return Ok(objResult);
        }
    }
}
