using Api_Domain.Dtos.Cep;
using Api_Domain.Interfaces.Services.Cep;
using ApiApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarUpdate
{
    public class RetornoOk
    {
        private CepsController _controller;

        [Fact(DisplayName = "É Possível realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_controller_Create()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
            new CepDtoUpdateResult
            {
                Id = Guid.NewGuid(),
                Logradouro = "Teste de rua",
                Cep = "10333444",
                UpdateAt = DateTime.UtcNow

            });
            _controller = new CepsController(serviceMock.Object);

            var cepDtoUpdate = new CepDtoUpdate
            {
                Logradouro = "Teste de rua",
                Cep = "10333444"
            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is OkObjectResult);

        }
    }
}
