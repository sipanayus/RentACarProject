using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
         IUserDal _userDal;
        

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
           
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

     
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserCreated);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IResult Update(User user)
        {
            //var currentUser = _userDal.Get(x => x.Id == user.Id);

            //var userForUpdate = new User()
            //{
            //    FirstName = user.FirstName,
            //    Email = user.Email,
            //    Id = user.Id,
            //    LastName = user.LastName,
            //    PasswordHash = currentUser.PasswordHash,
            //    PasswordSalt = currentUser.PasswordSalt,
            //    Status = currentUser.Status

            //};
            //_userDal.Update(userForUpdate);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
        public IDataResult<User> GetByMail(string email)
        {
            var getByMail = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(getByMail);
            // return new SuccessDataResult<List<User>>(_userDal.GetByMail(User));
        }

    }
}
