/*
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using WebApiTest.Domain.Entities;

namespace WebApiTest.Application.Features.Adjunto.Specifications
{
    internal class AdjuntoByIdentificacionAndFeatureSpec
    {
    }
}
*/

using Ardalis.Specification;
using WebApiTest.Domain.Entities;

namespace WebApiTest.Application.Features.Adjunto.Specifications;

public class AdjuntoByIdentifiacionAndFeatureSpec : Specification<Adjuntos>
{
    public AdjuntoByIdentifiacionAndFeatureSpec(string Identificacion, string IdFeature, string idSolicitud)
    {
        if (string.IsNullOrEmpty(idSolicitud))
            Query.Where(p => p.Identificacion == Identificacion && p.IdFeature == IdFeature && p.Estado == "A").OrderByDescending(x => x.FechaCreacion);
        else
            Query.Where(p => p.Identificacion == Identificacion && p.IdFeature == IdFeature && p.IdSolicitud == idSolicitud && p.Estado == "A").OrderByDescending(x => x.FechaCreacion);
    }
}
