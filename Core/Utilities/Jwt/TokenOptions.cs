using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; } //Yani bizim tokenimizin kullanıcı kitlesi
        public string Issuer { get; set; } //İmzalayan gibi düşünebiliriz.
        public int AccessTokenExpiration { get; set; } //Bu tokenimiz için süresel olarak ne kadar erişim belirteci olacağını söylüyor.
        public string SecurityKey { get; set; } //güvenlik anahtarı.


    }
}
