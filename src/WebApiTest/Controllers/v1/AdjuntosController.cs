/*
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Commands.GetAdjunto;
using WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto;
using WebApiTest.Application.Features.Adjunto.Commands.UpdateAdjunto;
using WebApiTest.Application.Features.Adjunto.Dto;
using WebApiTest.Controllers;

namespace WebApiTest.Controllers.v1
{
    public class AdjuntosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
*/

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Commands.GetAdjunto;
using WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto;
using WebApiTest.Application.Features.Adjunto.Commands.UpdateAdjunto;
using WebApiTest.Application.Features.Adjunto.Dto;
using WebApiTest.Controllers;

namespace WebUtilsApi.Controllers.v1;

[ApiVersion("1.0")]

public class AdjuntosController : ApiControllerBase
{
    /// <summary>
    /// Procesar Adjuntos
    /// </summary>
    /// <param name="request">Procesa y guarda los adjuntos</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("ProcesarAdjunto")]
    [EnableCors("AllowOrigin")]
    [ProducesResponseType(typeof(ResponseType<string>), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<IActionResult> ProcesarAdjunto([FromBody] ProcesarAdjuntoRequest request, CancellationToken cancellationToken)
    {
        var objResult = await Mediator.Send(new ProcesarAdjuntoCommand(request), cancellationToken);
        return Ok(objResult);
    }

    /// <summary>
    /// Obtener Adjuntos
    /// </summary>
    ///<param name="identificacion"></param>
    ///<param name="idFeature"></param>
    ///<param name="idSolicitud" description="opcional"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetAdjunto")]
    [EnableCors("AllowOrigin")]
    [ProducesResponseType(typeof(ResponseType<string>), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<IActionResult> GetAdjunto(string identificacion, string idFeature, string? idSolicitud, CancellationToken cancellationToken)
    {
        var objResult = await Mediator.Send(new GetAdjuntoCommand(identificacion, idFeature, idSolicitud), cancellationToken);
        return Ok(objResult);
    }

    [HttpPut("UpdateAdjunto")]
    [EnableCors("AllowOrigin")]
    [ProducesResponseType(typeof(ResponseType<string>), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateAdjunto(string AdjuntoId, CancellationToken cancellationToken)
    {
        var objResult = await Mediator.Send(new UpdateAdjuntoCommand(AdjuntoId), cancellationToken);
        return Ok(objResult);
    }

    [HttpGet("GetAdjuntoWallet")]
    [EnableCors("AllowOrigin")]
    [ProducesResponseType(typeof(ResponseType<AdjuntoTypeWallet>), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<IActionResult> GetAdjuntoWallet(string Identificacion, string IdFeature, CancellationToken cancellationToken)
    {
        var objResult = await Mediator.Send(new GetAdjuntoWalletCommand(Identificacion, IdFeature), cancellationToken);
        return Ok(objResult);
    }

    [HttpPost("NewProcesarAdjunto")]
    [EnableCors("AllowOrigin")]
    [ProducesResponseType(typeof(ResponseType<string>), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<IActionResult> NewProcesarAdjunto(CancellationToken cancellationToken)
    {
        List<NewProcesarAdjuntoRequest> request = new();

        if (HttpContext.Request.HasFormContentType)
        {
            var parametros = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            var files = HttpContext.Request.Form.Files.Count > 0 ? HttpContext.Request.Form.Files : null;

            if (files is not null)
            {
                foreach (var fi in files)
                {
                    byte[] archivo;

                    using (var stream = new MemoryStream())
                    {
                        fi.CopyTo(stream);
                        archivo = stream.ToArray();
                    }

                    request.Add(new NewProcesarAdjuntoRequest()
                    {
                        IdSolicitud = parametros["IdSolicitud"],
                        Identificacion = parametros["IdentificacionEmpleado"],
                        IdTipoSolicitud = parametros["IdTipoSolicitud"],
                        IdFeature = parametros["IdFeature"],
                        ArchivoByte = archivo,
                        NombreArchivo = Path.GetFileNameWithoutExtension(fi.Name),
                        ExtensionArchivo = Path.GetExtension(fi.FileName)
                    });
                }
            }
        }

        var objResult = await Mediator.Send(new NewProcesarAdjuntoCommand(request), cancellationToken);
        return Ok(objResult);
    }

}