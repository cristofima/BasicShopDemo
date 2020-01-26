using BasicShopDemo.Api.Core;
using BasicShopDemo.Api.Core.DTO;
using BasicShopDemo.Api.Extensions;
using BasicShopDemo.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.DAO
{
    public class ProviderDAO
    {
        private readonly BasicShopContext context;
        public CustomError customError;

        /// <summary>
        /// Class for database access
        /// </summary>
        /// <param name="context">Object for database</param>
        public ProviderDAO(BasicShopContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all providers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Provider> GetAll(Query query)
        {
            var result = context.Provider
                .ApplyQuery(query)
                .ToList();

            return result;
        }

        /// <summary>
        /// Get a provider by Id
        /// </summary>
        /// <param name="id">Provider Id</param>
        /// <returns></returns>
        public async Task<Provider> GetByIdAsync(int id)
        {
            return await context.Provider.FindAsync(id);
        }

        /// <summary>
        /// Add a provider
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(Provider provider)
        {
            context.Provider.Add(provider);
            await context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Modify a provider
        /// </summary>
        /// <param name="provider">Provider data</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Provider provider)
        {
            if (!context.Provider.Any(e => e.Id == provider.Id))
            {
                var errors = new Dictionary<string, List<string>>
                {
                    { "Id", new List<string>() { $"The provider with id '{provider.Id}' does not exist" } }
                };

                customError = new CustomError(404, errors);

                return false;
            }

            context.Entry(provider).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Delete a provider by Id
        /// </summary>
        /// <param name="id">Provider Id</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var provider = await GetByIdAsync(id);
            if (provider == null)
            {
                var errors = new Dictionary<string, List<string>>
                {
                    { "Id", new List<string>() { $"The provider with id '{id}' does not exist, it was probably deleted by another user" } }
                };

                customError = new CustomError(404, errors);
                return false;
            }

            context.Provider.Remove(provider);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
