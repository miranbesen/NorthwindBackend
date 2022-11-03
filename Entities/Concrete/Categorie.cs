using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Categorie:IEntity
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}
