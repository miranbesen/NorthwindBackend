using Business.Abstract;
using Business.Contant;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategorieManager : ICategorieService
    {
        private ICategorieDal _categorieDal;

        public CategorieManager(ICategorieDal categorieDal)
        {
            _categorieDal = categorieDal;
        }

        public IResult Add(Categorie categorie)
        {
            _categorieDal.Add(categorie);
            return new SuccessResult(Messages.CategorieAdded);
        }

        public IResult Delete(Categorie categorie)
        {
            _categorieDal.Delete(categorie);
            return new SuccessResult(Messages.CategorieDeleted);
        }

        public IDataResult<Categorie> GetById(int categorietId)
        {
            return new SuccessDataResult<Categorie>(_categorieDal.Get(filter: p => p.CategoryID == categorietId));
        }

        public IDataResult<List<Categorie>> GetList()
        {
            return new SuccessDataResult<List<Categorie>>(_categorieDal.GetList().ToList());
        }

        public IResult Update(Categorie categorie)
        {
            _categorieDal.Update(categorie);
            return new SuccessResult(Messages.CategorieUpdated);
        }
    }
}
