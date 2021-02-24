using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int Id);
        IDataResult<List<Product>> GetByUnitPrice(Decimal min ,Decimal max);
        IDataResult<List<ProductDetailsDto>> GetProductDetails();
        IDataResult<Product> GetById(int id);
        IResult Add(Product product);
        IResult Update(Product product);

    }
}
