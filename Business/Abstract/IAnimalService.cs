using Core.Utilities.Results.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnimalService
    {
        IResult Add(Animal animal);
        IResult Delete(Animal animal);
        IResult Update(Animal animal);
        IDataResult<List<Animal>> GetById(int id);
        IDataResult<List<Animal>> GetAll();
    }
}
