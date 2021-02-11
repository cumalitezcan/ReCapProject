using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
             BrandManager brandManager = new BrandManager(new EfBrandDal());
             ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("Rent a car app");

            //Region içerisindeki çoklu yorum operatörünü kaldırınız.

            Console.WriteLine("CarCrudOperation");
            #region CarCRUDOperation
            /*
             Car car1 = new Car()
             {
                 BrandId = 3,
                 ColorId = 3,
                 DailyPrice = 75,
                 ModelYear="2002",
                 Descriptions="Manuel Benzin"
             };

            //carManager.Add(car1);

            //Update İşlemi
            //carManager.Update(new Car {Id=1002,BrandId=3,ColorId=3,ModelYear="2002",DailyPrice=55,Descriptions="Manuel Benzin" });
            
            //CarList(carManager);
            //Console.WriteLine();

            //carManager.Delete(new Car{ Id=1002});
            //CarList(carManager);
            */
            #endregion

            
            Console.WriteLine("BrandCrudOperation");
            #region BrandCRUDOperation
            /*
            brandManager.Add(new Brand()
            {
                BrandName = "Ferrari"
            });

            brandManager.Update(new Brand()
            { 
             BrandId = 1002,
             BrandName="Alfa Romeo"});

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
            Console.WriteLine();


            brandManager.Delete(new Brand
            {
                BrandId = 1002
            });

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
            */

            #endregion

            
            Console.WriteLine("ColorCrudOperation");
            #region ColorCRUDOperation

            /*
            colorManager.Add(new Color()
            {
                ColorName = "Koyu Gri"
            });

            colorManager.Update(new Color()
            {
                ColorId = 1002,
                ColorName = "Metalik Gri"
            });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine();


            colorManager.Delete(new Color
            {
                ColorId = 1002
            });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            */

            #endregion
            
            
            Console.WriteLine("DtoCarDetail");
            #region UseDtoCarDetail
            /*
            foreach (var dtoCar in carManager.GetCarDetails())
            {
                Console.WriteLine(dtoCar.CarId + "/" + dtoCar.BrandName + "/" + dtoCar.ColorName + "/" + dtoCar.DailyPrice);
            }
            */
            #endregion
            

            
            Console.WriteLine("UseGetById");
            #region GetCarId
            /*
            Console.WriteLine();

            //Id'ye göre getir
            Car item = carManager.GetById(2);
            Console.WriteLine(item.Id+"/"+item.Descriptions);
            Console.WriteLine();

            //Brand Id'ye göre getir
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.BrandId+"/"+car.Descriptions);
            }
            Console.WriteLine();

            //Color Id'ye göre getir
            foreach (Car car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.ColorId+"/"+car.Descriptions);
            }
            */
            #endregion

        }

        private static void CarList(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(" " + car.Id + "/" + car.DailyPrice + "/" + car.Descriptions);
            }
        }
    }
}
