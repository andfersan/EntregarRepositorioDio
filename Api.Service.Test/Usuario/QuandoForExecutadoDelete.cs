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
    public class QuandoForExecutadoDelete : UsuarioTestes
    {
        private IUserService _service;

        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = " É possível executar o método delete.")]
        public async Task E_Possivel_Executar_Metodo_delete()
        {
            // Faz uma imitação do real 
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(IdUsuario)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            // Responderá se for om mesmo IdUsuario.
            var deletado = await _service.Delete(IdUsuario);
            Assert.True(deletado);

            // Mocar se caso resultado for falso.
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }

    }
}
