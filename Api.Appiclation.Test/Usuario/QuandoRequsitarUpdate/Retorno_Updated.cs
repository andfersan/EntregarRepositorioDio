using Api_Domain.Dtos.User;
using Api_Domain.Interfaces.Services.User;
using ApiApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Appiclation.Test.Usuario.QuandoRequsitarUpdate
{
    public class Retorno_Updated
    {
        private UsersController _controller;

        [Fact(DisplayName = "É Possível realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_controller_Update()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                new UserDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    UpdateAt = DateTime.UtcNow
                });

            _controller = new UsersController(serviceMock.Object);

            var userDtoUpdate = new UserDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name =nome,
                Email = email,
            };
            var result = await _controller.Put(userDtoUpdate);
            // Teste
            Assert.True(result is OkObjectResult);
            // var resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            UserDtoUpdateResult resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoUpdate.Name, resultValue.Name);
            Assert.Equal(userDtoUpdate.Email, resultValue.Email);
        }

        
    }
}
