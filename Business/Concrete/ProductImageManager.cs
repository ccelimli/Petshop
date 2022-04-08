using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        IImageHelper _imageHelper;

        public ProductImageManager(IImageHelper imageHelper, IProductImageDal productImageDal)
        {
            _imageHelper = imageHelper;
            _productImageDal = productImageDal;
        }

        public IResult Add(IFormFile file, ProductImage productImage)
        {
            IResult result=BusinessRules.Run()
        }

        public IResult Delete(ProductImage productImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductImage>> GetAll(Expression<Func<ProductImage, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductImage>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, ProductImage productImage, string destination)
        {
            throw new NotImplementedException();
        }
    }
}
