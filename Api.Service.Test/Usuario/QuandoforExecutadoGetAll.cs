﻿using Api_Domain.Dtos.User;
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
    public class QuandoforExecutadoGetAll : UsuarioTestes
    {
        private IUserService _service;

        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o método GetAll.")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IUserService>();
           _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(ListaUserDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _ListResult = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_ListResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);

        }

    }
}
