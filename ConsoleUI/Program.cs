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

            Console.WriteLine("Araç Bilgileri...");
            Listele(carManager);
            

            //Yeni Araba Ekleme
            /*carmanager.add(new car()
            {
                brandıd = 3,
                colorıd = 3,
                modelyear = "2010",
                dailyprice = 100,
                descriptions = "manuel dizel"
            });*/


            //Araba Bilgisi Güncelleme
           /* carmanager.update(new car
            {
                ıd = 6,
                brandıd = 3,
                colorıd = 3,
                modelyear = "2010",
                dailyprice = 110,
                descriptions = "manuel dizel"

            //}) ;*/

                //Araba Silme İşlemi
                //carManager.Delete(new Car() { Id = 6 });

            //BrandId'ye Göre Listeleme
            /* foreach (var item in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(item.BrandId + "  " + item.Descriptions);
            }*/


        }

        private static void Listele(CarManager carManager)
        {
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id + "-" + item.BrandId + "-" + item.ColorId + "-" +item.ModelYear +"-" + item.DailyPrice+ "-" +item.Descriptions);
            }
        }
    }
}
