using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Eventos.Commands;
using WebApiTest.Application.Features.Eventos.Commands.GetListaEventos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ListaEventosController : ApiControllerBase
    {
        [HttpGet("GetListadoEventos")]
        [EnableCors("AllowOrigin")]
        [ProducesResponseType(typeof(ResponseType<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEventos()
        {
            var objResult = await Mediator.Send(new GetListEventosCommand());

            return Ok(objResult);
        }
    }
}
