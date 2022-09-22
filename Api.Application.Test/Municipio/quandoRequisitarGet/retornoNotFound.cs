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

namespace Api.Application.Test.Municipio.quandoRequisitarGet
{
    public class retornoNotFound
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É Possível realizar o Get.")]
        public async Task E_Possivel_Invocar_a_controller_Get()
        {
            var serviceMock = new Mock<IMunicipioService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDto)null));

            _controller = new MunicipiosController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);

        }
    }
}
