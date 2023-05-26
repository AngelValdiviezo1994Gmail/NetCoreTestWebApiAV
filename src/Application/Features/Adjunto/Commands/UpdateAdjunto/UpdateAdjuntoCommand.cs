/*
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Interfaces;

namespace WebApiTest.Application.Features.Adjunto.Commands.UpdateAdjunto
{
    internal class UpdateAdjuntoCommand
    {
    }
}
*/

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Interfaces;
using WebApiTest.Domain.Entities;

namespace WebApiTest.Application.Features.Adjunto.Commands.UpdateAdjunto;

public record UpdateAdjuntoCommand(string AdjuntoId) : IRequest<ResponseType<string>>;

public class UpdateAdjuntoCommandHandler : IRequestHandler<UpdateAdjuntoCommand, ResponseType<string>>
{
    private readonly IAdjuntoService _repositoryAsync;


    public UpdateAdjuntoCommandHandler(IMapper mapper, IAdjuntoService repositoryAsync)
    {
        _repositoryAsync = repositoryAsync;
    }

    public async Task<ResponseType<string>> Handle(UpdateAdjuntoCommand request, CancellationToken cancellationToken)
    {
        var objresult = await _repositoryAsync.UpdateAdjunto(request.AdjuntoId, cancellationToken);
        return objresult;
    }

}
