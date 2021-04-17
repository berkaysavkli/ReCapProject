using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult  <List<Car>> GetAll();
        IDataResult <List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult <List<CarDetailDto>> GetCarsByColorId(int id);
        IDataResult <List<CarDetailDto>> GetCarDetails();
        IDataResult <Car> GetById(int id);
        IResult Add (Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionalTest(Car car);
    }
}
