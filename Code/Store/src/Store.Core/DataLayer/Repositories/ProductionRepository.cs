using System;
using System.Collections.Generic;
using System.Linq;
using Store.Core.DataLayer.Contracts;
using Store.Core.EntityLayer.Production;

namespace Store.Core.DataLayer.Repositories
{
    public class ProductionRepository : Repository, IProductionRepository
    {
        public ProductionRepository(UserInfo userInfo, StoreDbContext dbContext)
            : base(userInfo, dbContext)
        {
        }

        public IEnumerable<Product> GetProducts()
        {
            return DbContext.Set<Product>();
        }

        public Product GetProduct(Product entity)
        {
            return DbContext.Set<Product>().FirstOrDefault(item => item.ProductID == entity.ProductID);
        }

        public Product GetProductByName(String productName)
        {
            return DbContext.Set<Product>().FirstOrDefault(item => item.ProductName == productName);
        }

        public void AddProduct(Product entity)
        {
            DbContext.Set<Product>().Add(entity);

            DbContext.SaveChanges();
        }

        public void UpdateProduct(Product changes)
        {
            var entity = GetProduct(changes);

            if (entity != null)
            {
                entity.ProductName = changes.ProductName;
                entity.ProductCategoryID = changes.ProductCategoryID;
                entity.UnitPrice = changes.UnitPrice;
                entity.Discontinued = changes.Discontinued;
                entity.Description = changes.Description;

                DbContext.SaveChanges();
            }
        }

        public void DeleteProduct(Product entity)
        {
            DbContext.Set<Product>().Remove(entity);

            DbContext.SaveChanges();
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return DbContext.Set<ProductCategory>();
        }

        public ProductCategory GetProductCategory(ProductCategory entity)
        {
            return DbContext.Set<ProductCategory>().FirstOrDefault(item => item.ProductCategoryID == entity.ProductCategoryID);
        }

        public void AddProductCategory(ProductCategory entity)
        {
            DbContext.Set<ProductCategory>().Add(entity);

            DbContext.SaveChanges();
        }

        public void UpdateProductCategory(ProductCategory changes)
        {
            var entity = GetProductCategory(changes);

            if (entity != null)
            {
                entity.ProductCategoryName = changes.ProductCategoryName;

                DbContext.SaveChanges();
            }
        }

        public void DeleteProductCategory(ProductCategory entity)
        {
            DbContext.Set<ProductCategory>().Remove(entity);

            DbContext.SaveChanges();
        }

        public IEnumerable<ProductInventory> GetProductInventories()
        {
            return DbContext.Set<ProductInventory>();
        }

        public ProductInventory GetProductInventory(ProductInventory entity)
        {
            return DbContext.Set<ProductInventory>().FirstOrDefault(item => item.ProductInventoryID == entity.ProductInventoryID);
        }

        public void AddProductInventory(ProductInventory entity)
        {
            DbContext.Set<ProductInventory>().Add(entity);

            DbContext.SaveChanges();
        }

        public void UpdateProductInventory(ProductInventory changes)
        {
            var entity = GetProductInventory(changes);

            if (entity != null)
            {
                entity.ProductID = changes.ProductID;
                entity.EntryDate = changes.EntryDate;
                entity.Quantity = changes.Quantity;

                DbContext.SaveChanges();
            }
        }

        public void DeleteProductInventory(ProductInventory entity)
        {
            DbContext.Set<ProductInventory>().Remove(entity);

            DbContext.SaveChanges();
        }
    }
}
