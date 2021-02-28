using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryProductDal()

        {
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=150000,ModelYear=2021,Description="Renault Clio"},
                new Car{Id=2,BrandId=2,ColorId=1,DailyPrice=250000,ModelYear=2021,Description="Peugeot 208"},
                new Car{Id=3,BrandId=3,ColorId=2,DailyPrice=350000,ModelYear=2021,Description="Skoda Karoq"},
                new Car{Id=4,BrandId=4,ColorId=2,DailyPrice=650000,ModelYear=2021,Description="BMW 3 Serisi"},
                new Car{Id=5,BrandId=5,ColorId=2,DailyPrice=4000000,ModelYear=2021,Description="Mercedes S Serisi"},
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //LİNQ kullanarak listeyi dolaşma
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            //SingleOrDefault her ürünü dolaşmaya yarar
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
       
                return _cars.Where(c => c.Id == Id).ToList();
            
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => car.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            
        }
    }
}
