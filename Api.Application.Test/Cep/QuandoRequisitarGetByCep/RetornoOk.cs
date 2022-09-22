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
    public class RetornoOk
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

            var result = await _controller.Get("13480000");
            Assert.True(result is OkObjectResult);

        }
    }
}
