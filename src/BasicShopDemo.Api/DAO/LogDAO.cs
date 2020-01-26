using BasicShopDemo.Api.Core;
using BasicShopDemo.Api.Core.DTO;
using BasicShopDemo.Api.Data;
using BasicShopDemo.Api.Extensions;
using BasicShopDemo.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace BasicShopDemo.Api.DAO
{
    public class LogDAO
    {
        private readonly ApplicationDbContext context;
        public CustomError customError;

        /// <summary>
        /// Class for database access
        /// </summary>
        /// <param name="context">Object for Database</param>
        public LogDAO(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all logs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Log> GetAll(Query query)
        {
            var result = context.Log
                .ApplyQuery(query)
                .ToList();

            return result;
        }
    }
}
