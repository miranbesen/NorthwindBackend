using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder) //konfigürasyonu yaptığımız yer.
        {
            builder.RegisterType<ProductManager>().As<IProductService>(); //Burada biri IProductService şeklinde bir şey isterse constructor'unda biz ona product manager veriyor olucaz.
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<CategorieManager>().As<ICategorieService>(); //Burada biri IProductService şeklinde bir şey isterse constructor'unda biz ona product manager veriyor olucaz.
            builder.RegisterType<EfCategorieDal>().As<ICategorieDal>();

        }
    }
}
