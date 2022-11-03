using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategorieService
    {
        IDataResult<Categorie> GetById(int categorietId);
        IDataResult<List<Categorie>> GetList();
        IResult Add(Categorie categorie);
        IResult Update(Categorie categorie);
        IResult Delete(Categorie categorie);
    }
}
