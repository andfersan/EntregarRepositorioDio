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

namespace Api.Application.Test.Cep.QuandoRequisitarGetByCep
{
    public class RetornoBadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É Possível realizar o Get.")]
        public async Task E_Possivel_Invocar_a_controller_Get()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<string>())).ReturnsAsync(
            new CepDto
            {
                Id = Guid.NewGuid(),
                Logradouro = "Teste de rua",

            });
            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
