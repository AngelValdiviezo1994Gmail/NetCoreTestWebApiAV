using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Acontecimientos.Commands.CreateAcontecimientos;
using WebApiTest.Application.Features.Acontecimientos.Dto;
using WebApiTest.Domain.Entities.Acontecimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Acontecimientos.Interfaces
{
    public interface IAcontecimientos
    {
        Task<ResponseType<string>> CreateAcontecimiento(CreateAcontecimientosRequest Request, CancellationToken cancellationToken);
        Task<ResponseType<string>> UpdateAcontecimiento(AcontecimientosModels Request, CancellationToken cancellationToken);
        Task<ResponseType<string>> DeleteLogicoAcontecimiento(AcontecimientosModels Request, CancellationToken cancellationToken);
    }
}
