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

namespace Api.Application.Test.Cep.QuandoRequisitarCreate
{
    public class RetornoCreated
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível realizar o Created.")]
        public async Task E_Possivel_Invocar_o_Controller_Create()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Post(It.IsAny<CepDtoCreate>())).ReturnsAsync(
                new CepDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de rua",
                    CreateAt = DateTime.UtcNow

                });
            _controller = new CepsController(serviceMock.Object);
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cepDtoCreate = new CepDtoCreate()
            {
                Logradouro = "Teste de rua",
                Numero = "",
            };

            var result = await _controller.Post(cepDtoCreate);
            Assert.True(result is CreatedResult);

        }
    }
}
