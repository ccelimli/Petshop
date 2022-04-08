﻿using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.Database;
using Entites.Concrete;
using PetShop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class BrandDal : EntityRepositoryBase<Brand,PetShopContext>,IBrandDal
    {  
    }
}