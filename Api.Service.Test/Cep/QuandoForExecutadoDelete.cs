using Api_Domain.Interfaces.Services.Cep;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoDelete : CepTeste
    {
        private ICepService _service;

        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(IdCep)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            //Realizar o Delete
            var deletado = await _service.Delete(IdCep);
            Assert.True(deletado);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            //Realizar o Delete
            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}
