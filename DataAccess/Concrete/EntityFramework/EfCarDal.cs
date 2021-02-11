using Core.DataAccess.EntityFramework;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, SunContext>, ICarDal
    {
        
        public List<CarDetailDto> GetCarDetails()
        {
            using (SunContext context = new SunContext())
            {
                var result = from car in context.Cars
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 CarName = car.Descriptions,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
