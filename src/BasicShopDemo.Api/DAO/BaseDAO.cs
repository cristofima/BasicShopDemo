using BasicShopDemo.Api.Core;
using BasicShopDemo.Api.Core.DTO;
using BasicShopDemo.Api.Core.Interfaces.DAO;
using BasicShopDemo.Api.Extensions;
using BasicShopDemo.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.DAO
{
    public abstract class BaseDAO<T> : IBaseDAO<T> where T : Entity
    {
        protected readonly BasicShopContext context;

        public CustomError customError;

        private string entityName;

        /// <summary>
        /// Class for database access
        /// </summary>
        /// <param name="context">Object for Database</param>
        /// <param name="entityName">Entity name</param>
        public BaseDAO(BasicShopContext context, string entityName)
        {
            this.context = context;
            this.entityName = entityName;
        }

        /// <summary>
        /// Add a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Delete a entity by Id
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                var errors = new Dictionary<string, List<string>>
                {
                    { "Id", new List<string>() { $"The {entityName} with id '{id}' does not exist, it was probably deleted by another user" } }
                };

                customError = new CustomError(404, errors);
                return false;
            }

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Query query)
        {
            var result = context.Set<T>()
                .ApplyQuery(query)
                .ToList();

            return result;
        }

        /// <summary>
        /// Get a entity by Id
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public CustomError GetCustomError()
        {
            return customError;
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
