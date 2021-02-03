using Business.Concrete;
using DataAccess.Concrete;
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

            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("---Araba Ekleme İşlemleri---");
            carManager.Add(new Car { Id = 4, BrandId = 6, ColorId = 7, ModelYear = 1999, DailyPrice = 14999, Description = "Renault-Broadway" });
            Console.WriteLine();

            Console.WriteLine("---Mevcut Arabalar---");
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
                
            }
            Console.WriteLine();

            Console.WriteLine("---Özel Araç Bilgisi---");
            foreach (var item in carManager.GetById(2))
            {
                Console.WriteLine("{0} id numaralı araç: {1} ",item.Id,item.Description);
            }

            Console.WriteLine();
            Console.WriteLine("---Araç Güncelleme İşlemi---");
            carManager.Update(new Car { Id = 4, BrandId = 4, ColorId = 4, ModelYear = 1997, DailyPrice = 12500, Description = "Renault-Spring" });

            Console.WriteLine("---Mevcut Araçlar---");
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);

            }
            Console.WriteLine();
            Console.WriteLine("Araç Silme İşlemi");
            carManager.Delete(new Car { Id = 4 });

            Console.WriteLine("---Mevcut Araçlar---");
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);

            }
            
        }
    }
}
