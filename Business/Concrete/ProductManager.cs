using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core;
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

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
            IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }
        [ValidationAspect(typeof(Product))]
        public IResult Add(Product product)
        {

            

            _productDal.Add(product);
            return new Result(true);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour==22)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenancaTime);
            //}

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=> p.CatagoryId ==Id));
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new  SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails());
        }
    }
}
