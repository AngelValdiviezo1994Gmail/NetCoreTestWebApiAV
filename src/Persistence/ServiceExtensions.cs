
using WebApiTest.Application.Common.Interfaces;
using WebApiTest.Application.Features.Acontecimientos.Interfaces;
using WebApiTest.Application.Features.Clientes.Interfaces;
using WebApiTest.Application.Features.Eventos.Interfaces;
using WebApiTest.Persistence.Contexts;
using WebApiTest.Persistence.Repository;
using WebApiTest.Persistence.Repository.Acontecimientos;
using WebApiTest.Persistence.Repository.Clientes;
using WebApiTest.Persistence.Repository.Eventos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiTest.Application.Features.Adjunto.Interfaces;

namespace WebApiTest.Persistence;
public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
               builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        /*
        services.AddDbContext<ApplicationsDbPanaceaContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("Bd_Rrhh_Panacea")));

        services.AddDbContext<ApplicationsDbMarcacionesContext>(options => 
                    options.UseSqlServer(configuration.GetConnectionString("Bd_Marcaciones_GRIAMSE")));
        */

        #region Repositories

        services.AddTransient(typeof(IRepositoryAsync<>), typeof(CustomRepositoryAsync<>));
        services.AddTransient<IAcontecimientos, AcontecimientoService>();
        services.AddTransient<IClientes, ClientesService>();
        services.AddTransient<IAdjuntoService, AdjuntoService>();
        #endregion

        return services;
    }

}