using Api_Domain.Dtos.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Usuario
{
    public class QuandoRequisitarUsuario : BaseIntegration
    {
        public string _name { get; set; }
        public string _email { get; set; }

        //[Fact]
        [Fact(Skip = "Teste ainda não disponivel")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
             await AdicionarToken();
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();

            var userDto = new UserDtoCreate()
            {
                Name = _name,
                Email = _email
            };
            // Post
            var response = await PostJsonAsyn(userDto, $"{hostApi}users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            //Problemas aqui!!!
            var registroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, registroPost.Name);
            Assert.Equal(_email, registroPost.Email);
            Assert.True(registroPost.Id != default(Guid));
           

            //GetAll
            response = await client.GetAsync($"{hostApi}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
            Assert.NotEmpty(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.True(listaFromJson.Where(r => r.Id == registroPost.Id).Count() == 1);

            var updateUserDto = new UserDtoUpdate()
            {
                Id = registroPost.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };
            //Put
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateUserDto),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}users", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<UserDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPost.Name, registroAtualizado.Name);
            Assert.NotEqual(registroPost.Email, registroAtualizado.Email);

            //Get Id
            response = await client.GetAsync($"{hostApi}users/{ registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<UserDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Name, registroAtualizado.Name);
            Assert.Equal(registroSelecionado.Email, registroAtualizado.Email);

            //Delete
            response = await client.DeleteAsync($"{hostApi}users/{ registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //Get Id depois do delete
            response = await client.DeleteAsync($"{hostApi}users/{ registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);


        }

    }
}
