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
    public class EfCarDal : ICarDal
    {
        public void Add(Car Entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var addedCar = context.Entry(Entity);
                
                if (addedCar.Entity.Description.Length >= 2 && addedCar.Entity.DailyPrice > 0)
                {
                    Console.WriteLine("Araba açıklaması en az 2 karakter olmalıdır.");
                }
                else if (addedCar.Entity.Description.Length >= 2 && addedCar.Entity.DailyPrice < 0)
                {
                    Console.WriteLine("Araba günlük fiyatı 0 dan büyük olmalıdır.");
                }
                else
                {
                    addedCar.State = EntityState.Added;
                    context.SaveChanges();
                }
                
            }
        }

        public void Delete(Car Entity)
        {
            using (ReCapProjectContext context =new ReCapProjectContext())
            {
                var deletedCar = context.Entry(Entity);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return context.Set<Car>().SingleOrDefault();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car Entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var updatedCar = context.Entry(Entity);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
