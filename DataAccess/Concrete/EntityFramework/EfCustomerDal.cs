using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, SunContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {

                using (SunContext context = new SunContext())
                {
                    var result = from cu in filter == null ? context.Customers : context.Customers.Where(filter)
                                 join us in context.Users
                                 on cu.UserId equals us.Id
                                
                                 select new CustomerDetailDto
                                 {
                                    CustomerId=cu.CustomerId,
                                    UserId=us.Id,
                                    CompanyName=cu.CompanyName,
                                    FirstName=us.FirstName,
                                    LastName=us.LastName,
                                    Email=us.Email,
                                    Status=us.Status
                                 };
                    return result.ToList();
                }
        




        }
    }
}
