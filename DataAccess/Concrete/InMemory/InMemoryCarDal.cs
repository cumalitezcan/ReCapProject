using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car(){ Id=1,BrandId=3,ColorId=5,ModelYear="1990",DailyPrice=35000,Descriptions="Fiat-Palio"},
                new Car(){ Id=2,BrandId=4,ColorId=6,ModelYear="1995",DailyPrice=45000,Descriptions="Hundai Accent"},
                new Car(){ Id=3,BrandId=5,ColorId=6,ModelYear="1999",DailyPrice=55000,Descriptions="Opel Astra"}
            };

            
        }

        public void Add(Car car)
        {
            
            _cars.Add(car);
            Console.WriteLine(car.Descriptions+" isimli araba eklendi");
        }

        public void Delete(Car car)
        {
             
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            var idGetir = from c in _cars
                          where c.Id == id
                          select c;

            return idGetir.ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
           
        }
    }
}

