using BasicShopDemo.Api.Core;
using BasicShopDemo.Api.Data;
using BasicShopDemo.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.DAO
{
    public class LogDAO
    {
        private readonly ApplicationDbContext context;
        public CustomError customError;

        /// <summary>
        /// Class for database access
        /// </summary>
        /// <param name="context">Object for database</param>
        public LogDAO(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all logs
        /// </summary>
        /// <returns></returns>
        public async Task<List<Log>> GetAllAsync()
        {
            return await context.Log.ToListAsync();
        }
    }
}
