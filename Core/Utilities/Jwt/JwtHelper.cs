using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //Configuration dosyasından okuyacaz.Yani appsettings.json da bulunan bilgileri okuyacaz configuration sayesinde.
        private DateTime _accessTokenExpiration;
        private TokenOptions _tokenOptions;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        
        }


        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //tokeni encrypt ederken bir tokene ihtiyacımız var, orada kullanıcaz bunu.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); //şimdi de bizim signing credentials bilgisini girmemiz gerekiyor. Buda bizim security key ve algoritmalarını belirlediğimiz bir nesnedir. 
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token=token,
                Expiration= _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, // Token oluşturmak için tercih ettiğimiz yöntem jwt'dir.
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims) //jwt oluşturan bir method. Gerekli olan parametreler ise jwt içinde kullanacağımız parametreler.
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires:_accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            //claims.Add(new Claim(type: "email", value: user.Email)); 

            //Claim nesnesini extend ediyor olacagız magic string yerine.
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName}{user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }
    }
}
