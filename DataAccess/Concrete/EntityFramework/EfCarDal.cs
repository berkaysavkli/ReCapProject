using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            //Burada 3 tabloyu join ederek arabaların ismi, markası, rengi ve günlük 
            //ücretini yanyana göstermiş olduk.
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();



            }
        }
    }
}
