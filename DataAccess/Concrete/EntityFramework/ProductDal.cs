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
                var GetProductDetail = from product in context.Products
                                       join category in context.Categories
                                       on product.CategoryId equals category.CategoryId
                                       join animal in context.Animals
                                       on product.AnimalId equals animal.AnimalId
                                       join brand in context.Brands
                                       on product.BrandId equals brand.BrandId
                                       select new ProductDetailDto
                                       {
                                           Id=product.ProductId,
                                           AnimalName = animal.AnimalName,
                                           CategoryName = category.CategoryName,
                                           BrandName = brand.BrandName,
                                           ProductName = product.ProductName,
                                           UnitPrice=product.UnitPrice,
                                           UnitsInStock=product.UnitsInStock,
                                       };
                return GetProductDetail.ToList();
            }
        }
        
    }
}
