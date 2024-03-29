﻿using Api_Data.Context;
using Api_Data.Implementations;
using Api_Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class UfGets : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public UfGets(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Gets de UF")]
        [Trait("GETs", "UfEntity")]
        public async Task E_Possivel_realizar_Gets_UF()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UfImplementation  _repositorio = new UfImplementation(context);
                UfEntity _entity = new UfEntity
                {
                    Id = new Guid("b32ee1cd-82d1-4d05-9b71-b674e947db00"),
                    Sigla = "AL",
                    Nome = "Alagoas"
                };
                var _registroExiste = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_entity.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_entity.Sigla, _registroSelecionado.Sigla);
                Assert.Equal(_entity.Nome, _registroSelecionado.Nome);
                Assert.Equal(_entity.Id, _registroSelecionado.Id);

                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                //Assert.True(_todosRegistros.Count() == 27);

            }

        }
    }
}
