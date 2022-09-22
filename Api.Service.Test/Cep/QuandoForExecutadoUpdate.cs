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
    public class QuandoForExecutadoUpdate : CepTeste
    {
        private ICepService _service;

        private Mock<ICepService> _serviceMock;

        //[Fact(DisplayName = "É Possivel executar o Método Update.")]
        [Fact(Skip = "Teste ainda não disponivel")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Put(cepDtoUpdate)).ReturnsAsync(cepDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(cepDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(resultUpdate.Cep,CepAlterado);
            Assert.Equal(LogradouroAlterado, resultUpdate.Logradouro);
            Assert.Equal(NumeroAlterado, resultUpdate.Numero);

        }

    }
}
