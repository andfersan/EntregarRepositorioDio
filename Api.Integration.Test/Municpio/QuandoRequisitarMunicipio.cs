using Api_Domain.Dtos.Municipio;
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

namespace Api.Integration.Test.Municpio
{
    public class QuandoRequisitarMunicipio : BaseIntegration
    {
        //[Fact]
        [Fact(Skip = "Teste ainda não disponivel")]
        public async Task E_Possivel_Realizar_Crud_Municipio()
        {
            await AdicionarToken();

            var municipioDto = new MunicipioDtoCreate()
            {
                Nome = "São Paulo",
                CodIBGE = 3550308,
                UfId = new Guid("5AFAEAED-E40D-4907-B1FB-18BF86C65264")
            };

            // Post
            var response = await PostJsonAsyn(municipioDto, $"{hostApi}Municipios", client);
            var postResult = await response.Content.ReadAsStringAsync();
            //Problemas aqui!!!
            var registroPost = JsonConvert.DeserializeObject<MunicipioDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("Sãp Paulo", registroPost.Nome);
            Assert.Equal(3550308, registroPost.CodIBGE);
            Assert.True(registroPost.Id != default(Guid));

            //GetAll
            response = await client.GetAsync($"{hostApi}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<MunicipioDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.True(listaFromJson.Where(r => r.Id == registroPost.Id).Count() == 1);

            var updateUserDto = new MunicipioDtoUpdate()
            {
                Id = registroPost.Id,
                Nome = "Limeira",
                CodIBGE = 3526902,
                UfId = new Guid("5AFAEAED-E40D-4907-B1FB-18BF86C65264")
            };

            //Put
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateUserDto),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}Municipios", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<MunicipioDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Limeira", registroAtualizado.Nome);
            Assert.Equal(3526902, registroAtualizado.CodIBGE);

            //Get Id
            response = await client.GetAsync($"{hostApi}Municipios/{ registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<MunicipioDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionado.CodIBGE, registroAtualizado.CodIBGE);

            //Get Complete/Id
            response = await client.GetAsync($"{hostApi}Municipios/Complete{ registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoCompleto = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(jsonResult);
            Assert.NotNull(registroSelecionadoCompleto);
            Assert.Equal(registroSelecionadoCompleto.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionadoCompleto.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoCompleto.Uf);
            Assert.Equal("São Paulo",registroSelecionadoCompleto.Uf.Nome);
            Assert.Equal("SP",registroSelecionadoCompleto.Uf.Sigla);


            //Get byIBGE/IBGE
            response = await client.GetAsync($"{hostApi}Municipios/byIBGE{ registroAtualizado.CodIBGE}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoIBGECompleto = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(jsonResult);
            Assert.NotNull(registroSelecionadoIBGECompleto);
            Assert.Equal(registroSelecionadoIBGECompleto.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionadoIBGECompleto.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoIBGECompleto.Uf);
            Assert.Equal("São Paulo", registroSelecionadoIBGECompleto.Uf.Nome);
            Assert.Equal("SP", registroSelecionadoIBGECompleto.Uf.Sigla);

            //Delete
            response = await client.DeleteAsync($"{hostApi}users/{ registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //Get Id depois do delete
            response = await client.DeleteAsync($"{hostApi}users/{ registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
