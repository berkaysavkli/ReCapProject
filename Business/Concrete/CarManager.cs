using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckCarDescriptionLimit(car.Description),
                CheckCarDailyPrice(car.DailyPrice));
            if (result != null)
            {
                return result;
            }
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        [CacheAspect(duration: 10)]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            //İş kodları
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        
        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        
        [CacheAspect]
        public IDataResult<List<CarDetailDto>>GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId));
        }

        
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.uptade,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        private IResult CheckCarDescriptionLimit(string description)
        {
            var result = description.Length;
            if (result <= 2)
            {
                return new ErrorResult(Messages.DescriptionInvalid);
            }
            return new SuccessResult();
        }

        private IResult CheckCarDailyPrice(decimal dailyPrice)
        {
            var result = dailyPrice;
            if (result < 0)
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
            }
            return new SuccessResult();
        }

        
    }   
}
