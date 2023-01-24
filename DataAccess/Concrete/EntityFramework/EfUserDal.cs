using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user) //User'de bulunan yetkilerin listesi.
        {
            using (var context = new NorthwindContext())
            {
                var result = from OperationClaim in context.OperationsClaims //OperationClaim ile useroperationclaims tablolarını joinledik operationclaim id'lerine göre ve user id'lere göre where koşulunu yazıp operationclaimlerin listesini result'a eşitledik.
                             join UserOperationClaim in context.UserOperationsClaims
                             on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };
                return result.ToList();
            }
        }
    }
}
