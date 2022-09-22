using Api_Domain.Dtos.Uf;
using Api_Domain.Interfaces.Services.Uf;
using ApiApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Uf.QuandoResuisitarGet
{
    public class RetornoOK
    {
        private UfsController _controller;

        [Fact(DisplayName = "É Possível realizar o Get.")]
        public async Task E_Possivel_Invocar_a_controller_Get()
        {
            var serviceMock = new Mock<IUfService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
            new UfDto
            {
                Id = Guid.NewGuid(),
                Nome = "Alagoas",
                Sigla = "AL"

            });
            _controller = new UfsController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

        }

    }
}
