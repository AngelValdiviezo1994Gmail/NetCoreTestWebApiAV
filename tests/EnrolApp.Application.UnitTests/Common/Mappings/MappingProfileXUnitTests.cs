using AutoMapper;
using WebApiTest.Application.Common.Mappings;
using WebApiTest.Application.Features.Billeteras.Dto;
using WebApiTest.Application.Features.Clients.Commands.CreateCliente;
using WebApiTest.Application.Features.Clients.Dto;
using WebApiTest.Application.Features.Employees.Dto;
using WebApiTest.Application.Features.Horarios.Dto;
using WebApiTest.Application.Features.Wallets.Dto;
using WebApiTest.Domain.Entities.Common;
using WebApiTest.Domain.Entities.Horario;
using WebApiTest.Domain.Entities.Nomina;
using WebApiTest.Domain.Entities.Wallet;
using System.Runtime.Serialization;
using Xunit;

namespace WebApiTest.Application.UnitTests.Common.Mappings
{
    public class MappingProfileXUnitTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingProfileXUnitTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }
        [Fact]
        public void ShouldBeValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(CreateClienteRequest), typeof(Cliente))]
        [InlineData(typeof(Cliente), typeof(ClienteType))]
        [InlineData(typeof(InformacionGeneralEmpleado), typeof(InformacionGeneralEmpleadoType))]
        [InlineData(typeof(CertificadoLaboral), typeof(CertificadoLaboralType))]
        [InlineData(typeof(AvisoEntrada), typeof(AvisoEntradaType))]
        [InlineData(typeof(RolPagoCabecera), typeof(RolPagoCabeceraType))]
        [InlineData(typeof(Rubro), typeof(RubroType))]
        [InlineData(typeof(RolPago), typeof(RolPagoType))]
        [InlineData(typeof(Horario), typeof(HorarioType))]
        [InlineData(typeof(CupoCredito), typeof(CupoCreditoResponseType))]
        [InlineData(typeof(SaldoContable), typeof(SaldoContableResponseType))]
        public void Map_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);

            _mapper.Map(instance, origin, destination);
        }
    }
}
