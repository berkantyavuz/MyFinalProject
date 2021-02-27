
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
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
        ICatagoryService _catagoryService;
        public ProductManager(IProductDal productDal,ICatagoryService categoryService)
        {
            _productDal = productDal;
            _catagoryService = categoryService;

            
        }

        public string ProductNameAlreadyExists { get; private set; }
        //Claim
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckProductNameExists(product.ProductName),
                              CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                              CheckIfProductCategoryLimit());



            if (result !=null)
            {
                return result;
            }
            
           _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

            //business codes
            

        }


        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<ProductDetailsDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                _productDal.Add(product);

                return new SuccessResult(Messages.ProductAdded);

            }
            return new ErrorResult();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId ==categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Count;
            if (result >=1)
            {
                return new ErrorResult(ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductCategoryLimit()
        {
            var result = _catagoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}