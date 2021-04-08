using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllTest();
            //GetCarsByBrandIdTest();
            //GetCarByColorIdTest();
            //GetCarDetailsTest();
            //GetByIdTest(); çalıştıramadım
            //CarAddTest();
            CustomerrAddTest();
            //UpdateTest();
            //DeleteTest();
        }
        private static void GetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Araba Id:" + car.Id + "  " + "Marka Id:" + car.BrandId + " " + "Renk Id:" + car.ColorId + " " + "Günlük Fiyatı:" + car.DailyPrice + " " + "Araba İsmi:" + car.Description + " " + "Model Yılı:" + car.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(3).Data)
            {
                Console.WriteLine(car.Description + " " + car.DailyPrice);
            }
        }
        private static void GetCarByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(car.Description+ " " + car.ModelYear+" " + car.DailyPrice);
            }
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Araba Adı:" + car.CarName + "  " + "Markası:" + car.BrandName + " " + "Rengi:" + car.ColorName + " " + "Günlük Fiyatı:" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        //private static void GetByIdTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetById(2))
        //    {
        //        Console.WriteLine(car);
        //    }
        //}
        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car carTest = new Car
            {
                Id = 9,
                BrandId =9 ,
                ColorId = 1,
                Description = "T",
                ModelYear = 2021,
                DailyPrice = 0
            };
            carManager.Add(carTest);
            
            
        }

        private static void UpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 6, DailyPrice = 230 });
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { ColorName="Mavi",Id=2});
        }

        private static void DeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { Id=6});

        }

        private static void CustomerrAddTest()
        {
            CustomerManager customerrManager = new CustomerManager(new EfCustomerDal());
            Customer customerTest = new Customer
            {
                Id=1,
                UserId=1,
                CompanyName="Test kiralama"
            };
            customerrManager.Add(customerTest);
            customerrManager.GetAll();


        }
    }
}
