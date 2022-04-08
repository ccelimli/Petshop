using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName == null || user.LastName == null || user.Email == null || user.Password == null)
            {
                return new ErrorResult(Messages.UserMissingInfo);
            }
            foreach (var users in _userDal.GetAll())
            {
                if (users.Email == user.Email)
                {
                    return new ErrorResult(Messages.UserRegistered);
                }
            }
            if (user.Password.Length < 6 || user.Password.Length > 20)
            {
                return new ErrorResult(Messages.UserPasswordInvalid);
            }
            else
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<List<User>> GetByFirstName(string FirstName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.FirstName == FirstName), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == Id), Messages.UserListed);
        }

        public IDataResult<List<User>> GetByLastName(string LastName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.LastName == LastName), Messages.UsersListed);
        }




        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
