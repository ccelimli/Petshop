using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using PetShop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class AnimalManager : IAnimalService
    {
        IAnimalDal _animalDal;

        public AnimalManager(IAnimalDal animalDal)
        {
            _animalDal = animalDal;
        }

        // Add
        [SecuredOperation("animal.add,admin")]
        [ValidationAspect(typeof(AnimalValidator))]
        public IResult Add(Animal animal)
        {
            _animalDal.Add(animal);
            return new SuccessResult(Messages.AnimalAdded);
        }

        //Delete
        [SecuredOperation("animal.delete,admin")]
        public IResult Delete(Animal animal)
        {
            _animalDal.Delete(animal);
            return new SuccessResult(Messages.AnimalDeleted);
        }

        // GetAll
        [CacheAspect]
        public IDataResult<List<Animal>> GetAll()
        {
            return new SuccessDataResult<List<Animal>>(_animalDal.GetAll(), Messages.AnimalsListed);
        }

        // GetById
        [CacheAspect]
        public IDataResult<List<Animal>> GetById(int id)
        {
            return new SuccessDataResult<List<Animal>>(_animalDal.GetAll(animal => animal.AnimalId == id), Messages.AnimalListed);
        }
        
        // Update
        [SecuredOperation("animal.delete,admin")]
        [ValidationAspect(typeof(AnimalValidator))]
        public IResult Update(Animal animal)
        {
            _animalDal.Update(animal);
            return new SuccessResult(Messages.AnimalUpdated);
        }
    }
}
