﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using FluentValidation;
using PetShop.DataAccess.Abstract;
using PetShop.Entites.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        // Add
        [SecuredOperation("Product.List,Admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        // Delete
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        // GetAll
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        // GetByAnimalId
        public IDataResult<List<Product>> GetByAnimalId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(product => product.AnimalId == id), Messages.ProductsListed);
        }

        // GetByBrandId
        public IDataResult<List<Product>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(product => product.BrandId == id), Messages.ProductsListed);
        }

        // GetById
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(product => product.ProductId == productId), Messages.ProductListed);
        }

        // GetProductDetails
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetail(), Messages.ProductsListed);
        }

        // Update
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
