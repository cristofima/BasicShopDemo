using BasicShopDemo.Api.Core.DTO;
using BasicShopDemo.Api.Core.ModelBinder;
using BasicShopDemo.Api.DAO;
using BasicShopDemo.Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult GetLog([ModelBinder(typeof(QueryModelBinder))] Query query)
        {
            return Ok(logDAO.GetAll(query));
        }
    }
}