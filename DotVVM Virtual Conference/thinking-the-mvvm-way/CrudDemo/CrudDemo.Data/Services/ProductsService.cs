using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudDemo.Data.Data;
using CrudDemo.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudDemo.Data.Services
{
    public class ProductsService
    {
        private readonly NorthwindContext db;

        public ProductsService(NorthwindContext db)
        {
            this.db = db;
        }


        public IQueryable<ProductListModel> GetProductsQuery(ProductFilter filter)
        {
            IQueryable<Products> products = db.Products;

            // apply filters
            if (filter.AvailableOnly)
            {
                products = products.Where(p => p.UnitsInStock > 0);
            }

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                products = products.Where(p => EF.Functions.Like(p.ProductName, $"%{filter.SearchText}%"));
            }

            // select only the columns that are displayed in the GridView
            // (it is not wise to pass the entire Products entity to the UI)
            // (we recommend to use AutoMapper - writing all these transforms is boring)
            IQueryable<ProductListModel> query = products.Select(p => new ProductListModel()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryName = p.Category.CategoryName,
                SupplierName = p.Supplier.CompanyName,
                QuantityPerUnit = p.QuantityPerUnit,
                UnitsInStock = p.UnitsInStock,
                UnitsOnOrder = p.UnitsOnOrder
            });

            return query;
        }

        public ProductDetailModel GetProductById(long id)
        {
            var p = db.Products.Find(id);

            return new ProductDetailModel()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryId = p.CategoryId,
                SupplierId = p.SupplierId,
                QuantityPerUnit = p.QuantityPerUnit,
                UnitsInStock = p.UnitsInStock,
                UnitsOnOrder = p.UnitsOnOrder
            };
        }

        public void SaveProduct(ProductDetailModel p)
        {
            Products entity;
            if (p.ProductId == 0)
            {
                entity = new Products();
            }
            else
            {
                entity = db.Products.Find(p.ProductId);
            }

            entity.ProductName = p.ProductName;
            entity.CategoryId = p.CategoryId;
            entity.SupplierId = p.SupplierId;
            entity.QuantityPerUnit = p.QuantityPerUnit;
            entity.UnitsInStock = p.UnitsInStock;
            entity.UnitsOnOrder = p.UnitsOnOrder;

            if (p.ProductId == 0)
            {
                db.Products.Add(entity);
            }

            db.SaveChanges();
        }

        public void ReorderProduct(long productId, long quantityToReorder)
        {
            var product = db.Products.Find(productId);
            product.UnitsOnOrder = (product.UnitsOnOrder ?? 0) + quantityToReorder;
            db.SaveChanges();
        }
    }
}
