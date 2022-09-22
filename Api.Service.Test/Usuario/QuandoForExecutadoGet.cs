using Api_Domain.Dtos.User;
using Api_Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGet : UsuarioTestes
    {
        // Referenciando para service.
        private IUserService _service;
        // Mock Fará uma imitação de todos os metodos da IUserService.
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.False(result.Id != IdUsuario);
            // Valor esperado e valor obtido
            Assert.Equal(NomeUsuario, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdUsuario);
            Assert.Null(_record);
        }

    }
}
