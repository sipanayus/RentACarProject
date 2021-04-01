using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand brand)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var addedBrand = context.Entry(brand);
                addedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand brand)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var deletedBrand = context.Entry(brand);
                deletedBrand.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        //public Brand Get(Expression<Func<Brand, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (RentalCarContext context =new RentalCarContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }


        public void Update(Brand brand)
        {
            using (RentalCarContext context =new RentalCarContext())
            {
                var updatedBrand = context.Entry(brand);
                updatedBrand.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
