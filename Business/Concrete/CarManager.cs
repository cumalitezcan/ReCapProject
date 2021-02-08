using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
           
            if (car.Descriptions.Length >= 2 && car.DailyPrice > 0)
            {
               _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Hatalı Giriş");
            }
         
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba başarıyla silindi");
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araba Bilgileri Başarıyla Güncellendi");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public Car GetById(int id)
        {
            
            return _carDal.Get(c => c.Id == id);
        }







        //public void Add()
        //{
        //    new Car {Id=6,BrandId=6,ColorId=7,ModelYear=1999,DailyPrice=19999,Description="asd"}


        //}

        //public List<Car> GetAll()
        //{
        //    return _carDal.GetById(3);
        //}


    }
}
