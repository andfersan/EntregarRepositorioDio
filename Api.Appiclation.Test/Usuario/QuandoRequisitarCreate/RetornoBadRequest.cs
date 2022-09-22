using Api_Domain.Dtos.User;
using Api_Domain.Interfaces.Services.User;
using ApiApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Appiclation.Test.Usuario.QuandoRequisitarCreate
{
    public class RetornoBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É Possível realizar o BadRequest.")]
        public async Task E_Possivel_Invocar_a_controller_Create()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            // Inicializar
            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(
                // Retorno
                new UserDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatório");
            // Inserir uma Url Mock
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            // Url Fake
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate
            {
                Name = nome,
                Email = email,
            };
            var result = await _controller.Post(userDtoCreate);
            Assert.True(result is BadRequestObjectResult);

        }

    }
}
