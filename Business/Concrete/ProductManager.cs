using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        //Yukarıda yapılan işlem Dependency Injection. Bizim iş sınıflarımız çalıştıktan sonra gerekli kurallar sağlanmış ise
        //Data Access ile iletişime geçmemiz gerekiyor. Ancak DataAccess katmanının soyut bir nesnesi ile iletişime geçiyoruz.
        //Çünkü Eğer herhangi bir data access sistemi ile iletişime geçersek, Proje yarın bir gün değişime uğrarsa kodlar üzerinde
        //Oynamamız gerekecektir. Yukarıda oluşturulan constructor yapısı ile ProductManager çalıştığında o ctor'da çalışır.
        //Ctor'un parametresine dikkatli bakıcak olursak. IProductDal türünde referans bir nesne istiyor.
        //Bu nesne ister InMemoryProductDal olur ister entityframeworkProductDal olur bunun kararı bize kalmış olur.

        public List<Product> GetAll()
        {
            //İş kodları 
            //Bir iş sınıfı başka sınıfları NEWLEMEZ.
            return _productDal.GetAll();
        }
    }
}
