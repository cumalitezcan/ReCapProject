using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult <List<Car>> GetAll();
        IDataResult <Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);

        IDataResult <List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsByCar(int Id);
        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByColor(int colorId);
        
    }
}
