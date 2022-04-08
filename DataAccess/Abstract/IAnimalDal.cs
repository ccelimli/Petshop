using Core.DataAccess;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DataAccess.Abstract
{
    public interface IAnimalDal : IEntityRepository<Animal>
    {
    }
}
