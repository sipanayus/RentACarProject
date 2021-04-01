﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color color)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var addedColor = context.Entry(color);
                addedColor.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Color color)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var deletedColor = context.Entry(color);
                deletedColor.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        //public Color Get(Expression<Func<Color, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RentalCarContext context =new RentalCarContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color color)
        {
            using (RentalCarContext context=new RentalCarContext())
            {
                var updatedColor = context.Entry(color);
                updatedColor.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}