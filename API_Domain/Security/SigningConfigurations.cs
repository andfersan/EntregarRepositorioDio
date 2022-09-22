using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api_Domain.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfigurations()
        {
            // Usando uma chave de 2048 bits
            // Quando o using cria a variavel provider, ele instacia RSA 
            using (var Provider =  new RSACryptoServiceProvider(2048))
            {
                // using cria trabalha com contexto e descarta quando ele sai do using.
                Key = new RsaSecurityKey(Provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
