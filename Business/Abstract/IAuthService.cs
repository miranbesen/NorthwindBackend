using Core.Entities.Concrete;
using Core.Utilities.Jwt;
using Core.Utilities.Result;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password); //kullanici kayit olması için yazdık.
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
