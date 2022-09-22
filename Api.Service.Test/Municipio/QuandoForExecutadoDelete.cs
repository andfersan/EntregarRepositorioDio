using Api_Domain.Interfaces.Services.Municpio;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoDelete : MunicipioTeste
    {

        private IMunicipioService _service;

        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Delete(IdMunicipio)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            //Realizar o Delete
            var deletado = await _service.Delete(IdMunicipio);
            Assert.True(deletado);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Delete(IdMunicipio)).ReturnsAsync(false);
            _service = _serviceMock.Object;

            //Realizar o Delete
            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}
