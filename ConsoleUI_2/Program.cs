using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryProductDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description+"  "+"Renk Kodu:"+ car.ColorId +" "+"Fiyatı:"+car.DailyPrice);
            }
        }
    }
}
