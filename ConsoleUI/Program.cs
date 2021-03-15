using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID (O HARFİ) -OPEN CLOSED PRINCIBLE- Ar-Ge
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAllByCategoryId(1))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
