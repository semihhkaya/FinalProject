using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

//Aşağıda ilk yapılan işlem Dependency Injection. Bizim iş sınıflarımız çalıştıktan sonra gerekli kurallar sağlanmış ise
//Data Access ile iletişime geçmemiz gerekiyor. Ancak DataAccess katmanının soyut bir nesnesi ile iletişime geçiyoruz.
//Çünkü Eğer herhangi bir data access sistemi ile iletişime geçersek, Proje yarın bir gün değişime uğrarsa kodlar üzerinde
//Oynamamız gerekecektir. Yukarıda oluşturulan constructor yapısı ile ProductManager çalıştığında o ctor'da çalışır.
//Ctor'un parametresine dikkatli bakıcak olursak. IProductDal türünde referans bir nesne istiyor.
//Bu nesne ister InMemoryProductDal olur ister entityframeworkProductDal olur bunun kararı bize kalmış olur.

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //Business Codes -- İş ihtiyaçlarımıza uygunluk
            //Validation -- Kontrol etme - Doğrulama - Parametre olarak girilen verinin Yapısı ile ilgili olan şeyler.
            _productDal.Add(product);
            
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public  IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
