/*
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Dto;
using WebApiTest.Application.Features.Adjunto.Interfaces;

namespace WebApiTest.Application.Features.Adjunto.Queries.GetAdjuntoWallet
{
    internal class GetAdjuntoWalletCommand
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

public record GetAdjuntoWalletCommand(string Identificacion, string IdFeature/*GetAdjuntoWalletRequest request*/) : IRequest<ResponseType<List<AdjuntoTypeWallet>>>;

public class GetAdjuntoWalletCommandHandler : IRequestHandler<GetAdjuntoWalletCommand, ResponseType<List<AdjuntoTypeWallet>>>
{
    private readonly IAdjuntoService _repositoryAsync;

    public GetAdjuntoWalletCommandHandler(IAdjuntoService repository)
    {
        _repositoryAsync = repository;
    }

    public async Task<ResponseType<List<AdjuntoTypeWallet>>> Handle(GetAdjuntoWalletCommand objCommand, CancellationToken cancellationToken)
    {
        var objresult = await _repositoryAsync.GetAdjuntoWallet(objCommand.Identificacion, objCommand.IdFeature, cancellationToken);
        return objresult;
    }
}

