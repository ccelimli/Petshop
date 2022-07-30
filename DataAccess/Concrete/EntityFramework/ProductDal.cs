using Core.DataAccess.EntityFramework;
using DataAccess.Context;
using Entites.Concrete;
using PetShop.DataAccess.Abstract;
using PetShop.Entites.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProductDal : EntityRepositoryBase<Product, PetShopContext>, IProductDal
    {
        
        public List<ProductDetailDto> GetProductDetail()
        {
            using (PetShopContext context = new PetShopContext())
            {
                var GetProductDetail = from p in context.Products
                                       join c in context.Categories
                                       on p.CategoryId equals c.CategoryId
                                       join a in context.Animals
                                       on p.AnimalId equals a.AnimalId
                                       join b in context.Brands
                                       on p.BrandId equals b.BrandId
                                       select new ProductDetailDto
                                       {
                                           AnimalName = a.AnimalName,
                                           CategoryName = c.CategoryName,
                                           BrandName = b.BrandName,
                                           ProductName = p.ProductName,
                                           UnitPrice=p.UnitPrice,
                                           UnitsInStock=p.UnitsInStock,
                                       };
                return GetProductDetail.ToList();
            }
        }
        
    }
}
