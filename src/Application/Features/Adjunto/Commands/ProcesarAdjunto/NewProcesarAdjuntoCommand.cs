/*
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Application.Common.Exceptions;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto;
using WebApiTest.Application.Features.Adjunto.Interfaces;
using WebApiTest.Domain.Entities;

namespace WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto
{
    internal class NewProcesarAdjuntoCommand
    {
    }
}
*/

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WebApiTest.Application.Common.Exceptions;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Interfaces;
using WebApiTest.Domain.Entities;

namespace WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto
{
    public record NewProcesarAdjuntoCommand(List<NewProcesarAdjuntoRequest> Request) : IRequest<ResponseType<string>>;

    public class NewProcesarAdjuntoCommandHandler : IRequestHandler<NewProcesarAdjuntoCommand, ResponseType<string>>
    {
        private readonly IAdjuntoService _repositoryAsync;
        private readonly IMapper _mapper;
        private readonly ILogger<NewProcesarAdjuntoCommandHandler> _log;

        public NewProcesarAdjuntoCommandHandler(IAdjuntoService repository, IMapper mapper, ILogger<NewProcesarAdjuntoCommandHandler> log)
        {
            _repositoryAsync = repository;
            _mapper = mapper;
            _log = log;
        }

        public async Task<ResponseType<string>> Handle(NewProcesarAdjuntoCommand objCommand, CancellationToken cancellationToken)
        {
            try
            {
                if (objCommand.Request.Any())
                {
                    var entity = _mapper.Map<List<Adjuntos>>(objCommand.Request);
                    var objresult = await _repositoryAsync.NewProcesarAdjunto(entity, cancellationToken);
                    return objresult;
                }
                else
                {
                    return new ResponseType<string>() { Message = "No existen archivos en la petición", StatusCode = "500", Succeeded = false };
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, string.Empty);
                return new ResponseType<string>() { Message = CodeMessageResponse.GetMessageByCode("500"), StatusCode = "500", Succeeded = false };
            }
        }
    }
}
