using Api_Domain.Dtos.Municipio;
using Api_Domain.Interfaces.Services.Municpio;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGet : MunicipioTeste
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = " É Possível Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Get(IdMunicipio)).ReturnsAsync(municipioDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdMunicipio);
            Assert.NotNull(result);
            // Alterado o sinal de == para != 
            Assert.False(result.Id != IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicipio, result.CodIBGE);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }

    }
}
