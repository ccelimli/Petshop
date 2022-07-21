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

        //Add
        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Add(IFormFile file, ProductImage productImage)
        {
            var result = BusinessRules.Run(CheckIfProductImageLimit(productImage.ProductId));
            if (result != null)
            {
                return result;
            }

            var resultofUpload = _imageHelper.Upload(file, PathConstant.ImagePath);
            if (!resultofUpload.Success)
            {
                return resultofUpload;
            }
            productImage.ImagePath = resultofUpload.Message;
            productImage.Date = DateTime.Now;

            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        //Delete
        public IResult Delete(ProductImage productImage)
        {
            var result = _imageHelper.Delete(PathConstant.ImagePath + productImage.ImagePath);
            if (!result.Success)
            {
                return result;
            }
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        //GetAll
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<ProductImage> GetByImageId(int Id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(productImage => productImage.Id == Id), Messages.ImageListed);
        }

        public IDataResult<List<ProductImage>> GetByProductId(int productId)
        {
            IResult result = BusinessRules.Run(CheckProductImageCount(productId));
            if (result != null)
            {
                return GetDefaultImage(productId);
            }
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(productImage => productImage.ProductId == productId), Messages.ImagesListed);
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            var result = _imageHelper.Update(file, PathConstant.ImagePath + productImage.ImagePath, PathConstant.ImagePath);
            if (!result.Success)
            {
                return result;
            }

            productImage.Date = DateTime.Now;
            productImage.ImagePath = result.Message;

            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        //GetDefaultImage
        private IDataResult<List<ProductImage>> GetDefaultImage(int productId)
        {
            var defaultProductImage = new List<ProductImage>();
            defaultProductImage.Add(new ProductImage { ProductId = productId, Date = DateTime.Now, ImagePath = "no-photos.png" });

            return new SuccessDataResult<List<ProductImage>>(defaultProductImage);
        }

        //CheckIfProductImageLimit
        private IResult CheckIfProductImageLimit(int productId)
        {
            var result = _productImageDal.GetAll(productImage => productImage.ProductId == productId);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.ProductImageLimitExceded);
            }
            return new SuccessResult();
        }

        //CheckProductImageCount
        private IResult CheckProductImageCount(int productId)
        {
            var result = _productImageDal.GetAll(productImage => productImage.ProductId == productId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
