using BasicShopDemo.Api.Core;
using BasicShopDemo.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.DAO
{
    public class CategoryDAO
    {
        private readonly BasicShopContext context;
        public CustomError customError;

        /// <summary>
        /// Class for database access
        /// </summary>
        /// <param name="context">Object for database</param>
        public CategoryDAO(BasicShopContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GetAllAsync()
        {
            return await context.Category.ToListAsync();
        }

        /// <summary>
        /// Get a category by Id
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns></returns>
        public async Task<Category> GetByIdAsync(int id)
        {
            return await context.Category.FindAsync(id);
        }

        /// <summary>
        /// Add a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(Category category)
        {
            context.Category.Add(category);
            await context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Modify a category
        /// </summary>
        /// <param name="category">Category data</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Category category)
        {
            if (!context.Category.Any(e => e.Id == category.Id))
            {
                var errors = new Dictionary<string, List<string>>
                {
                    { "Id", new List<string>() { $"The category with id '{category.Id}' does not exist" } }
                };

                customError = new CustomError(404, errors);

                return false;
            }

            context.Entry(category).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Delete a category by Id
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category == null)
            {
                var errors = new Dictionary<string, List<string>>
                {
                    { "Id", new List<string>() { $"The category with id '{id}' does not exist, it was probably deleted by another user" } }
                };

                customError = new CustomError(404, errors);
                return false;
            }

            context.Category.Remove(category);
            await context.SaveChangesAsync();

            return true;
        }
    }
}