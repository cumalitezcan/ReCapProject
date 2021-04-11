using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        private readonly ICarService _carService;

        public CustomerManager(ICustomerDal customerDal, ICarService carService)
        {
            _customerDal = customerDal;
            _carService = carService;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.CustomerId==id));
        }

        

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetailById(int customerId)
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(c => c.CustomerId == customerId),"Customer");

        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
        public void AddFindeksScore(int customerId, int carId)
        {
            var score = _carService.CalculateFindeksScore(carId);
            var customer = _customerDal.Get(c => c.CustomerId == customerId);
            if (customer.FindeksScore < 1900)
            {
                var newCustomerScore = customer.FindeksScore + score;
                Update(new Customer { CustomerId = customer.CustomerId, UserId = customer.UserId, CompanyName = customer.CompanyName, FindeksScore = (int)newCustomerScore });

            }

        }
    }
}
