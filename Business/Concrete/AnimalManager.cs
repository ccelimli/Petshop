using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class AnimalManager : IAnimalService
    {
        AnimalDal _animalDal;

        public AnimalManager(AnimalDal animalDal)
        {
            _animalDal = animalDal;
        }

        // Add
        public IResult Add(Animal animal)
        {
            if (animal.AnimalName.Length < 2)
            {
                return new ErrorResult(Messages.AnimalNameInvalid);
            }
            else
            {
                _animalDal.Add(animal);
                return new SuccessResult(Messages.AnimalAdded);
            }
        }

        //Delete
        public IResult Delete(Animal animal)
        {
            _animalDal.Delete(animal);
            return new SuccessResult(Messages.AnimalDeleted);
        }

        // GetAll
        public IDataResult<List<Animal>> GetAll()
        {
            return new SuccessDataResult<List<Animal>>(_animalDal.GetAll(), Messages.AnimalsListed);
        }

        // GetById
        public IDataResult<List<Animal>> GetById(int id)
        {
            return new SuccessDataResult<List<Animal>>(_animalDal.GetAll(animal => animal.AnimalId == id),Messages.AnimalListed);
        }

        // Update
        public IResult Update(Animal animal)
        {
            _animalDal.Update(animal);
            return new SuccessResult(Messages.AnimalUpdated);
        }
    }
}
