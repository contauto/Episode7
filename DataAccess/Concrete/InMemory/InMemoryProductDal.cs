using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
            new Product{ProductId=1,CategoryId=1,ProductName="Laptop",UnitPrice=4000,UnitsInStock=5},
            new Product{ProductId=2,CategoryId=1,ProductName="Desktop",UnitPrice=3000,UnitsInStock=4},
            new Product{ProductId=3,CategoryId=2,ProductName="Mouse",UnitPrice=50,UnitsInStock=30},
            new Product{ProductId=4,CategoryId=2,ProductName="Keyboard",UnitPrice=60,UnitsInStock=20},
            new Product{ProductId=5,CategoryId=2,ProductName="Camera",UnitPrice=1000,UnitsInStock=10}
            };
        }



        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            product.ProductName = productToUpdate.ProductName;
            product.CategoryId = productToUpdate.CategoryId;
            product.UnitPrice = productToUpdate.UnitPrice;
            product.UnitsInStock = productToUpdate.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        List<Product> IEntityRepository<Product>.GetAll(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Product IEntityRepository<Product>.Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
