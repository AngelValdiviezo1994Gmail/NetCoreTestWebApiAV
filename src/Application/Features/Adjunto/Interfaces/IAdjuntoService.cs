using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Adjunto.Commands.ProcesarAdjunto;
using WebApiTest.Application.Features.Adjunto.Dto;
using WebApiTest.Domain.Entities;

namespace WebApiTest.Application.Features.Adjunto.Interfaces
{
    public interface IAdjuntoService
    {
        Task<ResponseType<string>> ProcesarAdjunto(ProcesarAdjuntoRequest request, CancellationToken cancellationToken);
        Task<ResponseType<List<AdjuntoType>>> GetAdjunto(string identificacion, string idFeature, string idSolicitud, CancellationToken cancellationToken);
        Task<ResponseType<string>> NewProcesarAdjunto(List<Adjuntos> request, CancellationToken cancellationToken);
        Task<ResponseType<string>> UpdateAdjunto(string AdjuntoId, CancellationToken cancellationToken);

        Task<ResponseType<List<AdjuntoTypeWallet>>> GetAdjuntoWallet(string identificacion, string idFeature, CancellationToken cancellationToken);
    }
}
