using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IRentalService _rentalService;
        

        public CarManager(ICarDal carDal,IRentalService rentalService)
        {
            _carDal = carDal;
            _rentalService = rentalService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
          IResult result =  BusinessRules.Run(CheckIfDescriptionsExists(car.Descriptions),
              CheckIfCarCountOfBrandCorrect(car.BrandId),
              CheckIfRentalLimitExceded());

            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);


               
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult <List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<Car> GetById(int id)
        {
            
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarDetailListed);
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 3)
            {
                return new ErrorResult("3 veya daha fazla marka var");
            }
            return new SuccessResult();
        }

        private IResult CheckIfDescriptionsExists(string descriptions)
        {
            var result = _carDal.GetAll(c => c.Descriptions == descriptions).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfRentalLimitExceded()
        {
            var result = _rentalService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult("Kiralama limiti aşıldı");
            }
            return new SuccessResult();
        }

    }

    
}
