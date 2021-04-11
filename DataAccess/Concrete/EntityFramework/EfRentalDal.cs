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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join b in context.Brands
                             on r.CarId equals b.Id
                             join c in context.Customers
                             on r.CustomerId equals c.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 BrandName = b.BrandName,
                                 CompanyName = c.CompanyName,
                                 
                             };
                return result.ToList();



            }
        }
    }
}
