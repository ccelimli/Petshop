using Core.Utilities.Results.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using PetShop.Entites.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetByBrandId(int id);
        IDataResult<List<Product>> GetByAnimalId(int id);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
    }
}
