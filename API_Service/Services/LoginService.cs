using Api_Domain.Dtos.User;
using Api_Domain.Entities;
using Api_Domain.Interfaces.Services.User;
using Api_Domain.Repository;
using Api_Domain.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Api_Service.Services
{
    public class LoginService : ILoginService
    {
        // Especificando quero usar a IUserRepository.
        private IUserRepository _repository;

        private SigningConfigurations _signingConfiguration;
        private TokenConfigurations _tokenConfigurations;

        public IConfiguration _configuration;
        public LoginService(IUserRepository repository,
                            SigningConfigurations signingConfigurations,
                            TokenConfigurations tokenConfigurations,
                            IConfiguration configuration)
        {
            _repository = repository;
            _signingConfiguration = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;

        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            var baseUser = new UserEntity();
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                // Se usuario não existir no banco de dados, retorna nulo.
                baseUser = await _repository.FindByLogin(user.Email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "falha ao autenticar"
                    };
                }
                else
                {
                        var identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // jti  o id do Token
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                        }
                        );
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);
                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SucessObject(createDate, expirationDate, token, baseUser);
                }

            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {

                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,

            });
            var token = handler.WriteToken(securityToken);
            return token;   
        }

        private object SucessObject(DateTime createDate, DateTime expirationDate, string token,UserEntity user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                name = user.Name,
                message = "Usuário logado com sucesso"
            };
        }
    }
}
