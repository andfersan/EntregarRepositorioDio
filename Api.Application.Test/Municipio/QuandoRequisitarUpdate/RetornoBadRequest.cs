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
    public class RetornoBadRequest
    {

        private MunicipiosController _controller;

        [Fact(DisplayName = "É possível realizar o Updated.")]
        public async Task E_Possivel_Invocar_o_Controller_Update()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.Put(It.IsAny<MunicipioDtoUpdate>())).ReturnsAsync(
                new MunicipioDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = "Alagoas",
                    UpdateAt = DateTime.UtcNow

                });
            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", " É um campo obrigatório");

            var municipioDtoUpdate = new MunicipioDtoUpdate()
            {
                Nome = "Alagoas",
                CodIBGE = 1,
            };

            var result = await _controller.Put(municipioDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
