using Api_Domain.Dtos.Cep;
using Api_Domain.Dtos.Municipio;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Cep
{
    public class QuandoRequisitarCep : BaseIntegration
    {

        //[Fact]
        [Fact(Skip = "Teste ainda não disponivel")]
        public async Task E_Possivel_Realizar_Crud_Cep()
        {
            {
                 // *****************ERRO
                await AdicionarToken();

                var municipioDto = new MunicipioDtoCreate()
                {
                    Nome = "São Paulo",
                    CodIBGE = 3550308,
                    UfId = new Guid("5AFAEAED-E40D-4907-B1FB-18BF86C65264")
                };

                // Post
                var response = await PostJsonAsyn(municipioDto, $"{hostApi}municipios", client);
                var postResult = await response.Content.ReadAsStringAsync();
                //Problemas aqui!!!
                var registroPost = JsonConvert.DeserializeObject<MunicipioDtoCreateResult>(postResult);
                Assert.Equal(HttpStatusCode.Created, response.StatusCode);
                Assert.Equal("São Paulo", registroPost.Nome);
                Assert.Equal(3550308, registroPost.CodIBGE);
                Assert.True(registroPost.Id != default(Guid));

                var cepDto = new CepDtoCreate()
                {
                    Cep = "13480180",
                    Logradouro = "Rua Boa Morte",
                    Numero = " até n°200",
                    MunicipioId = registroPost.Id
                };

                //Post
                response = await PostJsonAsyn(municipioDto, $"{hostApi}Municipios", client);
                postResult = await response.Content.ReadAsStringAsync();
                //Problemas aqui!!!
                var registroCepPost = JsonConvert.DeserializeObject<CepDtoCreateResult>(postResult);
                Assert.Equal(HttpStatusCode.Created, response.StatusCode);
                Assert.Equal(cepDto.Cep, registroCepPost.Cep);
                Assert.Equal(cepDto.Logradouro, registroCepPost.Logradouro);
                Assert.True(registroCepPost.Id != default(Guid));

                var cepMunicipioDto = new CepDtoUpdate()
                {
                    Id = registroCepPost.Id,
                    Cep = "13480180",
                    Logradouro = "Rua da Liberdade",
                    Numero = " até n°200",
                    MunicipioId = registroPost.Id
                };

                //Put
                var stringContent = new StringContent(JsonConvert.SerializeObject(cepMunicipioDto),
                                        Encoding.UTF8, "application/json");
                response = await client.PutAsync($"{hostApi}Municipios", stringContent);
                var jsonResult = await response.Content.ReadAsStringAsync();
                var registroAtualizado = JsonConvert.DeserializeObject<CepDtoUpdateResult>(jsonResult);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(cepMunicipioDto.Logradouro, registroAtualizado.Logradouro);

                //Get Id
                response = await client.GetAsync($"{hostApi}ceps/{ registroAtualizado.Id}");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                jsonResult = await response.Content.ReadAsStringAsync();
                var registroSelecionado = JsonConvert.DeserializeObject<CepDto>(jsonResult);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(cepMunicipioDto.Logradouro, registroAtualizado.Logradouro);


                //Get Cep
                response = await client.GetAsync($"{hostApi}ceps/byCep/{ registroAtualizado.Id}");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                jsonResult = await response.Content.ReadAsStringAsync();
                registroSelecionado = JsonConvert.DeserializeObject<CepDto>(jsonResult);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(cepMunicipioDto.Logradouro, registroAtualizado.Logradouro);
                       
                //Delete
                response = await client.DeleteAsync($"{hostApi}ceps{ registroSelecionado.Id}");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                //Get Id depois do delete
                response = await client.DeleteAsync($"{hostApi}ceps/{ registroSelecionado.Id}");
                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
        }
    }
}
