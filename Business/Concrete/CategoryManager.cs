using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entites.Concrete;
using PetShop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        
        // Add
        public IResult Add(Category category)
        {
            if (category.CategoryName.Length<2)
            {
                return new ErrorResult(Messages.CategoryNameInvalid);
            }
            else
            {
                _categoryDal.Add(category);
                return new SuccessResult(Messages.CategoryAdded);
            }
        }

        // Delete
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        // GetAll
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>( _categoryDal.GetAll(), Messages.CategoriesListed);
        }

        //GetById
        public IDataResult<List<Category>> GetById(int id)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(category => category.CategoryId == id), Messages.CategoryListed);
        }

        //Update
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
