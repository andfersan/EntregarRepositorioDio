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

namespace Api.Application.Test.Municipio.QuandoRequisitarGetAll
{
    public class RetornoBadRequest
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É Possível realizar o GetAll.")]
        public async Task E_Possivel_Invocar_a_controller_GetAll()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
            new List<MunicipioDto>
            {
                new MunicipioDto
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                },
                new MunicipioDto
                {
                    Id = Guid.NewGuid(),
                    Nome = "Itaquaquecetuba",
                }
            });

            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");
            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
