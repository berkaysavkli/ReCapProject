using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Araba Adı:" + car.CarName + "  " + "Markası:" + car.BrandName + " " + "Rengi:" + car.ColorName + " " + "Günlük Fiyatı:" + car.DailyPrice);
            }
        }
    }
}
