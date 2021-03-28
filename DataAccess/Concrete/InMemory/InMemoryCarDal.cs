using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car {Id = 1, ColorId = 1, BrandId = 1, ModelYear=2011,DailyPrice=100, Description="Karavan Modeli" },
                new Car {Id = 1, ColorId = 1, BrandId = 2, ModelYear=2010,DailyPrice=100, Description="Kapalı Van Modeli" },
                new Car {Id = 1, ColorId = 2, BrandId = 3, ModelYear=2012,DailyPrice=100, Description="Açık Camlı Van Modeli" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car cartoDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(cartoDelete);
        }

        public List<Car> getAll()
        {
            return _cars;
        }

        public List<Car> getById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car updatedCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.Description = car.Description;
        }
    }
}
