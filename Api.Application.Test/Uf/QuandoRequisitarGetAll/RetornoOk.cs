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

namespace Api.Application.Test.Uf.QuandoRequisitarGetAll
{
    public class RetornoOk
    {
        private UfsController _controller;

        [Fact(DisplayName = "É Possível realizar o GetAll.")]
        public async Task E_Possivel_Invocar_a_controller_GetAll()
        {
            var serviceMock = new Mock<IUfService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
            new List<UfDto>
            {
                new UfDto
                {
                    Id = Guid.NewGuid(),
                    Nome = "Alagoas",
                    Sigla = "AL"
                },
                new UfDto
                {
                   Id = Guid.NewGuid(),
                   Nome = "São Paulo",
                   Sigla = "SP"
                }

            });

            _controller = new UfsController(serviceMock.Object);
            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

        }
    }
}
