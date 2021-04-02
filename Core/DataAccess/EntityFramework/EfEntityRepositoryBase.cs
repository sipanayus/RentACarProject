using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>

        where TEntity : class, IEntity, new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity car)
        {
            using (TContext context = new TContext())
            {
                var addedCar = context.Entry(car);
                addedCar.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity car)
        {
            using (TContext context = new TContext())
            {
                var deletedCar = context.Entry(car);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList()
                   : context.Set<TEntity>().Where(filter).ToList();
            }
        }


        public void Update(TEntity car)
        {
            using (TContext context = new TContext())
            {
                var updatedCar = context.Entry(car);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
