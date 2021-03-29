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
    public class EfColorDal : IColorDal
    {
        public void Add(Color Entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var addedColor = context.Entry(Entity);
                addedColor.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color Entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var deletedColor = context.Entry(Entity);
                deletedColor.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return context.Set<Color>().SingleOrDefault();
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color Entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var updatedColor = context.Entry(Entity);
                updatedColor.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}