using BasicShopDemo.Api.DAO;
using BasicShopDemo.Api.Data;
using BasicShopDemo.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.Controllers
{
    /// <summary>
    /// Services to list logs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize(Roles = "Administrator")]
    public class LogsController : ControllerBase
    {
        private LogDAO logDAO;

        public LogsController(ApplicationDbContext context)
        {
            logDAO = new LogDAO(context);
        }

        /// <summary>
        /// Get all registered logs
        /// </summary>
        /// <returns>All Logs</returns>
        // GET: api/Logs
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Log>>> GetLog()
        {
            return await logDAO.GetAllAsync();
        }
    }
}