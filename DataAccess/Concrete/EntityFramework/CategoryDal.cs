using Core.DataAccess.EntityFramework;
using DataAccess.Context;
using Entites.Concrete;
using PetShop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CategoryDal :EntityRepositoryBase<Category,PetShopContext> ,ICategoryDal
    {   
    }
}
