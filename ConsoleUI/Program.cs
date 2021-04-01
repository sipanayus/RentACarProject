using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorManager carManager = new ColorManager(new EfColorDal());

            foreach (var car in carManager.GetByColorId(2))
            {
                Console.WriteLine(car.ColorName);
            }
            
        }
    }
}
