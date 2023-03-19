using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dto;
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

        // Add
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(CheckAlreadyRegisteredUser(user.Email, user.PhoneNumber));

            if (result != null)
            {
                return result;
            }
            else
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
        }

        // Delete
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        // GetAll
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        // GetByEmail
        [CacheAspect]
        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(user => user.Email == email), Messages.UserListed);
        }

        // GetByFirstName
        [CacheAspect]
        public IDataResult<List<User>> GetByFirstName(string Name)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(user => user.FirstName == Name), Messages.UsersListed);
        }

        // GetById
        [CacheAspect]
        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(user => user.Id == Id), Messages.UserListed);
        }

        // GetByLastName
        [CacheAspect]
        public IDataResult<List<User>> GetByLastName(string lastName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(user => user.LastName == lastName), Messages.UsersListed);
        }

        // GetByPhoneNumber
        [CacheAspect]
        public IDataResult<User> GetByPhoneNumber(string PhoneNumber)
        {
            return new SuccessDataResult<User>(_userDal.Get(user => user.PhoneNumber == PhoneNumber));
        }

        // Update
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        // GetClaims
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        // CheckAlreadyRegisteredUser
        private IResult CheckAlreadyRegisteredUser(string email, string phoneNumber)
        {
            var resultEmail = _userDal.GetAll(user => user.Email == email).Any();
            var resultPhoneNumber = _userDal.GetAll(user => user.PhoneNumber == phoneNumber).Any();

            if (resultEmail)
            {
                return new ErrorResult(Messages.AlreadyRegistedEmail);
            }
            if (resultPhoneNumber)
            {
                return new ErrorResult(Messages.AlreadyRegistedPhoneNumber);
            }
            else
            {
                return new SuccessResult();
            }
        }

        //GetUserDetails
        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(), Messages.UsersListed);
        }
    }
}
