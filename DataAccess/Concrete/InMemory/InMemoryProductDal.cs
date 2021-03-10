using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //Bu bir global değişkendir. alt çizgi ifadesi ile beraber kullanılır.
        public InMemoryProductDal() //Bellekte InMemoryProductDal classı referans alındığında nesnesi oluştugunda çalışcak blok ctor bloğu (Class ile aynı isme sahip method)
        {
            _products = new List<Product> {
                new Product{ProductId=1,CateogryId=1,ProductName="Bardak",UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2,CateogryId=1,ProductName="Kamera",UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3,CateogryId=2,ProductName="Telefon",UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4,CateogryId=2,ProductName="Klavye",UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5,CateogryId=2,ProductName="Fare",UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //SingleOrDefault = Gönderilen veri kaynağını tek tek gezmeye yarar (_products listesi)
            //SingleOrDefault parantez içi = [p=>] = p takma adı ile  gezinen listedeki elemanalrın product id'lerini al
            //delete methoduna gönderilen product idler ile kontrol et eğer hem p hem product'ın idleri eşitse productToDelete'e ürünlerin referansını eşitle
            //Ardından _products.Remove methoduna productToDelete'i ver.

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CateogryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün idsine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CateogryId = product.CateogryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
