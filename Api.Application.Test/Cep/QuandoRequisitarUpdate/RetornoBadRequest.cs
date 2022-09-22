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
    public class RetornoBadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível realizar o Updated.")]
        public async Task E_Possivel_Invocar_o_Controller_Update()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                new CepDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de rua",
                    UpdateAt = DateTime.UtcNow

                });

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", "É um campo obrigatório");
            var cepDtoUpdate = new CepDtoUpdate
            {

                Logradouro = "Teste de rua",
                Numero = "10333444"

            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
