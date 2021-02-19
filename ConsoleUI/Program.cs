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
            //AddCustomer();
            //ReturnDateError();
            //CarDetailList();
            //RentalList();

        }

        private static void RentalList()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var item in rentalManager.GetAll().Data)
            {
                Console.WriteLine(item.CarId + "/" + item.CustomerId + "/" +
                    item.RentDate + "/" + item.ReturnDate);
            }
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer
            {
                UserId = 4,
                CompanyName = "Togg Otomobil"
            });
            Console.WriteLine(result.Message);
        }

        private static void CarDetailList()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CarName + "/" + item.BrandName + "/" + item.ColorName);
            }
        }

        private static void ReturnDateError()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = DateTime.Now
            });
            Console.WriteLine(result.Message);
        }

      



    }
}
