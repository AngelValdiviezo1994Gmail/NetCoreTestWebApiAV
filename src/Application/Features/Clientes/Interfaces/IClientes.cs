using WebApiTest.Application.Common.Wrappers;
using WebApiTest.Application.Features.Acontecimientos.Commands.CreateAcontecimientos;
using WebApiTest.Application.Features.Clientes.Commands.CreateClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Application.Features.Clientes.Interfaces
{
    public interface IClientes
    {
        Task<ResponseType<string>> CreateCliente(CreateClientesRequest Request, CancellationToken cancellationToken);
    }
}
