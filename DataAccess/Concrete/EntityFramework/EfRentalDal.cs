﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, SunContext>, IRentalDal
    {

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (SunContext context = new SunContext())
            {
                var result = from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join cu in context.Customers
                             on rental.CustomerId equals cu.CustomerId
                             join us in context.Users
                             on cu.UserId equals us.Id
                             join co in context.Colors
                             on car.ColorId equals co.ColorId
                             

                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 CompanyName = cu.CompanyName,
                                 BrandName = b.BrandName,
                                 CarName =  car.Name,
                                 CarId = rental.CarId,
                                 ColorName = co.ColorName,
                                 ModelYear=car.ModelYear,
                                 Descriptions = car.Descriptions,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = rental.RentDate ,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
