using WebApiTest.Domain.Entities.Acontecimientos;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApiTest.Application.Features.Acontecimientos.Specifications
{
    public class AcontecimientosByIdSpec : Specification<AcontecimientosModels>
    {
        public AcontecimientosByIdSpec(int id)
        {
            Query.Where(x => x.idAcontecimiento == id)
                .Include(x => x.idAcontecimiento);
        }
    }
}
