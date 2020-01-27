using BasicShopDemo.Api.Core;
using BasicShopDemo.Api.Core.Interfaces.DAO;
using BasicShopDemo.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.DAO
{
    public class CategoryDAO : BaseDAO<Category>, ICategoryDAO
    {
        /// <summary>
        /// Class for database access
        /// </summary>
        /// <param name="context">Object for Database</param>
        public CategoryDAO(BasicShopContext context) : base(context, "category")
        {
        }

        /// <summary>
        /// Modify a category
        /// </summary>
        /// <param name="category">Category data</param>
        /// <returns></returns>
        public new async Task<bool> UpdateAsync(Category category)
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
    }
}