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
        
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (SunContext context = new SunContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join cimg in context.CarImages
                             on car.Id equals cimg.CarId
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 CarName = car.Name,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 ImagePath = cimg.ImagePath,
                                 Date = cimg.Date,
                                 ImageId = cimg.Id,
                                 ModelYear = car.ModelYear,
                                 Descriptions = car.Descriptions,
                                 Status = !context.Rentals.Any(r => r.CarId == car.Id && (r.ReturnDate == null || r.ReturnDate > DateTime.Now))
                             };
                return result.ToList();
            }
        }


       
       
    }
}
