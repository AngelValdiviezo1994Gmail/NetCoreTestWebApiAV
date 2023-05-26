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
    internal class ProcesarAdjuntoCommand
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

namespace WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto;

public record ProcesarAdjuntoCommand(ProcesarAdjuntoRequest request) : IRequest<ResponseType<string>>;

public class ProcesarAdjuntoCommandHandler : IRequestHandler<ProcesarAdjuntoCommand, ResponseType<string>>
{
    private readonly IAdjuntoService _repositoryAsync;
    private readonly IMapper _mapper;
    private readonly ILogger<Adjuntos> _log;

    public ProcesarAdjuntoCommandHandler(IAdjuntoService repository, IMapper mapper, ILogger<Adjuntos> log)
    {
        _repositoryAsync = repository;
        _mapper = mapper;
        _log = log;
    }

    public async Task<ResponseType<string>> Handle(ProcesarAdjuntoCommand objCommand, CancellationToken cancellationToken)
    {
        try
        {
            //var entity = _mapper.Map<Adjuntos>(objCommand.request);
            var objresult = await _repositoryAsync.ProcesarAdjunto(objCommand.request, cancellationToken);
            return objresult;
        }
        catch (Exception ex)
        {
            _log.LogError(ex, string.Empty);
            return new ResponseType<string>() { Message = CodeMessageResponse.GetMessageByCode("102"), StatusCode = "102", Succeeded = false };
        }



    }
}


