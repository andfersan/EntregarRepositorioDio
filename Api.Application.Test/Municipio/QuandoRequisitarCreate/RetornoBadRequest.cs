using Api_Domain.Dtos.Municipio;
using Api_Domain.Interfaces.Services.Municpio;
using ApiApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarUpdate
{
    public class Retorno_BadRequest
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível realizar o Created.")]
        public async Task E_Possivel_Invocar_o_Controller_Create()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.Post(It.IsAny<MunicipioDtoCreate>())).ReturnsAsync(
                new MunicipioDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = "Alagoas",
                    CreateAt = DateTime.UtcNow

                });
            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", " É um campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var municipioDtoCreate = new MunicipioDtoCreate
            {
                Nome = "Alagoas",
                CodIBGE = 1,
            };

            var result = await _controller.Post(municipioDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
