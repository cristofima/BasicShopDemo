using BasicShopDemo.Api.Core;
using BasicShopDemo.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.DAO
{
    public class ProductDAO
    {
        private readonly BasicShopContext context;
        public CustomError customError;

        /// <summary>
        /// Class for database access
        /// </summary>
        /// <param name="context">Object for database</param>
        public ProductDAO(BasicShopContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAllAsync()
        {
            return await context.Product.ToListAsync();
        }

        /// <summary>
        /// Get a Product by Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Product.FindAsync(id);
        }

        /// <summary>
        /// Add a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(Product product)
        {
            Product duplicateProduct;
            Dictionary<string, List<string>> errors = null;

            duplicateProduct = context.Product.FirstOrDefault(c => c.Name == product.Name);

            if (duplicateProduct != null)
            {
                if (errors == null)
                {
                    errors = new Dictionary<string, List<string>>();
                }

                errors.Add("Name", new List<string>() { $"There is already a Product with the name '{product.Name}'" });
            }

            duplicateProduct = context.Product.FirstOrDefault(c => c.Code == product.Code);
            if (duplicateProduct != null)
            {
                if (errors == null)
                {
                    errors = new Dictionary<string, List<string>>();
                }

                errors.Add("Code", new List<string>() { $"There is already a Product with the code '{product.Code}'" });
            }

            var category = context.Category.Find(product.CategoryId);
            if (category == null)
            {
                if (errors == null)
                {
                    errors = new Dictionary<string, List<string>>();
                }

                errors.Add("CategoryId", new List<string>() { $"The Category with id '{product.CategoryId}' does not exist" });
            }
            else if (category.Status == false)
            {
                if (errors == null)
                {
                    errors = new Dictionary<string, List<string>>();
                }

                errors.Add("Category", new List<string>() { $"The Category '{category.Name}' is INACTIVE" });
            }

            if (errors != null && errors.Count > 0)
            {
                customError = new CustomError(400, errors);
                return false;
            }

            context.Product.Add(product);
            await context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Modify a Product
        /// </summary>
        /// <param name="product">Product data</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Product product)
        {
            Dictionary<string, List<string>> errors = null;

            if (!context.Product.Any(e => e.Id == product.Id))
            {
                if (errors == null)
                {
                    errors = new Dictionary<string, List<string>>();
                }

                errors.Add("Id", new List<string>() { $"The Product with id '{product.Id}' does not exist" });
                customError = new CustomError(404, errors);

                return false;
            }

            Product duplicateProduct;

            duplicateProduct = context.Product.FirstOrDefault(c => c.Name == product.Name && c.Id != product.Id);
            if (duplicateProduct != null)
            {
                if (errors == null)
                {
                    errors = new Dictionary<string, List<string>>();
                }

                errors.Add("Name", new List<string>() { $"There is already a Product with the name '{product.Name}'" });
            }

            duplicateProduct = context.Product.FirstOrDefault(c => c.Code == product.Code && c.Id != product.Id);
            if (duplicateProduct != null)
            {
                if (errors == null)
                {
                    errors = new Dictionary<string, List<string>>();
                }

                errors.Add("Code", new List<string>() { $"There is already a Product with the code '{product.Code}'" });
            }

            var category = context.Category.Find(product.CategoryId);
            if (category == null)
            {
                if (errors == null)
                {
                    errors = new Dictionary<string, List<string>>();
                }

                errors.Add("CategoryId", new List<string>() { $"The Category with id '{product.CategoryId}' does not exist" });
            }
            else if (category.Status == false)
            {
                if (errors == null)
                {
                    errors = new Dictionary<string, List<string>>();
                }

                errors.Add("Category", new List<string>() { $"The Category '{category.Name}' is INACTIVE" });
            }

            if (errors != null && errors.Count > 0)
            {
                customError = new CustomError(400, errors);
                return false;
            }

            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Delete a Product by Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var Product = await GetByIdAsync(id);
            if (Product == null)
            {
                Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

                errors.Add("Id", new List<string>() { $"The Product with id '{id}' does not exist, it was probably deleted by another user" });

                customError = new CustomError(404, errors);
                return false;
            }

            context.Product.Remove(Product);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
