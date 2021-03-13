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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            //Select count(*) from Rentals,Cars where Rentals.CarId = Cars.Id
            var rentalReturnDate = _rentalDal.GetAll(r=>r.CarId == rental.CarId);

            //count(*)>0
            if (rentalReturnDate.Count > 0)
            {
                
                foreach (var rrdate in rentalReturnDate)
                {
                    //Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.
                    //Bu şart ReturnDate içinde null varsa karşılanamamaktadır.
                    if (rrdate.ReturnDate == null)
                    {
                        return new ErrorResult(Messages.RentalInvalid);
                    }
                }
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalList);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),"araç kiralama listesi");
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
