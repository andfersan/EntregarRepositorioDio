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
    public class QuandoForExecutadoCreate : UsuarioTestes
    {
        private IUserService _service;

        private Mock<IUserService> _serviceMock;

        //[Fact(DisplayName = " É possível executar o método create.")]
        [Fact(Skip = "Teste ainda não disponivel")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {    // Arrrange
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;
            // Act
            // Esperando de que devolva um objeto
            var result = await _service.Post(userDtoCreate);
            //Assert
            Assert.NotNull(result);
            // Comparar valores, devem ser iguais.
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(NomeUsuario, result.Name);
            
        }


    }
}
