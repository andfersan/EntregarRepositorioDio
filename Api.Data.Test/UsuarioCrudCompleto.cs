using Api_Data.Context;
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
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }
        // Metodo para executar o teste.
        [Fact(DisplayName = "CRUD Usuario")]
        [Trait("CRUD", "UserEntity")]

        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                // tenho um repositorio
                UserImplementation _repositorio = new UserImplementation(context);
                //preciso obter uma entidade
                UserEntity _entity = new UserEntity
                {
                    //baixar o pacote faker.core para preenchimento automatico de nomes falsos e emails falsos.
                    //Email = "teste@gmail.com",
                    //Name = "teste",
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };
                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                //Assert.Equal("teste@gmail.com", _registroCriado.Email);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                //Assert.Equal("teste", _registroCriado.Name);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False( _registroCriado.Id == Guid.Empty);


                // Teste de Update 
                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);

                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
                // Se o registro for verdade, existe mesmo, então o teste deixa passar.
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                //Valor esperado, Valor atual.
                Assert.Equal(_registroAtualizado.Email, _registroSelecionado.Email);
                Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);
                                                        // Quando não passo parametros, ele retorna uma IEnumerable<UserEntity>.
                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                //contar os registros
                Assert.True(_todosRegistros.Count() > 1 );

                var _removeu = await _repositorio.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                var _usuarioPadrao = await _repositorio.FindByLogin("and@teste.com");
                // Usuario padrao esta na classe Mycontext.
                Assert.NotNull(_usuarioPadrao);
                Assert.Equal("and@teste.com", _usuarioPadrao.Email);
                Assert.Equal("Administrador", _usuarioPadrao.Name);
                    


            }
        }
    }
}
