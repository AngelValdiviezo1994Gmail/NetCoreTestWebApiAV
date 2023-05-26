/*
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Interfaces;

namespace WebApiTest.Application.Features.Adjunto.Commands.GetAdjunto
{
    internal class GetAdjuntoCommand
    {
    }
}

*/

using AutoMapper;
using MediatR;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Dto;
using WebApiTest.Application.Features.Adjunto.Interfaces;
using WebApiTest.Domain.Entities;

namespace WebApiTest.Application.Features.Adjunto.Commands.GetAdjunto;

public record GetAdjuntoCommand(string Identificacion, string IdFeature, string IdSolicitud) : IRequest<ResponseType<List<AdjuntoType>>>;

public class GetAdjuntoCommandHandler : IRequestHandler<GetAdjuntoCommand, ResponseType<List<AdjuntoType>>>
{
    private readonly IAdjuntoService _repositoryAsync;

    public GetAdjuntoCommandHandler(IAdjuntoService repository)
    {
        _repositoryAsync = repository;
    }

    public async Task<ResponseType<List<AdjuntoType>>> Handle(GetAdjuntoCommand objCommand, CancellationToken cancellationToken)
    {
        var objresult = await _repositoryAsync.GetAdjunto(objCommand.Identificacion, objCommand.IdFeature, objCommand.IdSolicitud, cancellationToken);
        return objresult;
    }
}

