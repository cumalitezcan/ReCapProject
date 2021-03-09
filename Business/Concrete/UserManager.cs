using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _user;
        public UserManager(IUserDal user)
        {
            _user = user;
        }
        public IResult Add(User user)
        {
            _user.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _user.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {

            return new SuccessDataResult<List<User>>(_user.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_user.Get(u => u.Id == userId));
        }
        public User GetByMail(string email)
        {
            return _user.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _user.GetClaims(user);
        }

        public IResult Update(User user)
        {
            _user.Delete(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
