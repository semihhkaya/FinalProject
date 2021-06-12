using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {//VOİD OLAN OPERASYONLARA IResult İmplementasyonunu kullandık. Mesaj ve True/False (başarı durumu) döndürdük
//Aynı olay IDataResult için de geçerli ancak. tek fark şu: IDataResult: Mesaj,başarıdurumu ve döndürülen listeyi veya veriyi içermeli
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult AddTransactionalTest(Product product);

    }
}
