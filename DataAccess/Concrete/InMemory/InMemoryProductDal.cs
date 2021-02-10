using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1, CatagoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=12, },
                new Product{ProductId=2, CatagoryId=1, ProductName="Kamera", UnitPrice=15, UnitsInStock=12, },
                new Product{ProductId=3, CatagoryId=2, ProductName="Telefon" ,UnitPrice=15, UnitsInStock=12, },
                new Product{ProductId=4, CatagoryId=2, ProductName="Klavye", UnitPrice=15, UnitsInStock=12, },
                new Product{ProductId=5, CatagoryId=2, ProductName="Fare", UnitPrice=15, UnitsInStock=12, }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
           
            Product productToDelete  = _products.SingleOrDefault(p=> p.ProductId == product.ProductId); 

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CatagoryId = product.CatagoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCatagory(int catagoryId)
        {
           return  _products.Where(p => p.CatagoryId == catagoryId).ToList();

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailsDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
