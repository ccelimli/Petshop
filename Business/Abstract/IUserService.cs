using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int Id);
        IDataResult<User> GetByPhoneNumber(string phoneNumber);
        IDataResult<List<User>> GetByFirstName(string FirstName);
        IDataResult<List<User>> GetByLastName(string LastName);
        IDataResult<User> GetByEmail(string Email);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
