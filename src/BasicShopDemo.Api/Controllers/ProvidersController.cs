using BasicShopDemo.Api.DAO;
using BasicShopDemo.Api.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.Controllers
{
    /// <summary>
    /// Services to save, modify or delete providers
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ODataRoutePrefix("Providers")]
    public class ProvidersController : ODataController
    {
        private ProviderDAO providerDAO;

        public ProvidersController(BasicShopContext context)
        {
            providerDAO = new ProviderDAO(context);
        }

        /// <summary>
        /// Get all registered providers
        /// </summary>
        /// <returns>All Providers</returns>
        // GET: api/Providers
        [HttpGet]
        [ProducesResponseType(200)]
        [EnableQuery]
        [ODataRoute]
        public async Task<ActionResult<IEnumerable<Provider>>> GetProvider()
        {
            return await providerDAO.GetAllAsync();
        }

        /// <summary>
        /// Get a provider according to your Id
        /// </summary>
        /// <returns>Provider data</returns>
        /// <param name="id">Provider Id</param>
        // GET: api/Providers/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [EnableQuery]
        [ODataRoute("({id})")]
        public async Task<ActionResult<Provider>> GetProvider(int id)
        {
            var provider = await providerDAO.GetByIdAsync(id);

            if (provider == null)
            {
                return NotFound();
            }

            return provider;
        }

        /// <summary>
        /// Modify a provider
        /// </summary>
        /// <returns>No Content if it was modified correctly</returns>
        /// <param name="id">Provider Id to Modify</param>
        /// <param name="provider">Provider data.</param>
        // PUT: api/Providers/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutProvider(int id, Provider provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != provider.Id)
            {
                return BadRequest();
            }

            if (!await providerDAO.UpdateAsync(provider))
            {
                return StatusCode(providerDAO.customError.StatusCode, providerDAO.customError);
            }

            return NoContent();
        }

        /// <summary>
        /// Register a new provider
        /// </summary>
        /// <returns>The data of the added provider</returns>
        /// <param name="provider">Provider data</param>
        // POST: api/Providers
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Provider>> PostProvider(Provider provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await providerDAO.AddAsync(provider))
            {
                return StatusCode(providerDAO.customError.StatusCode, providerDAO.customError);
            }

            return CreatedAtAction("GetProvider", new { id = provider.Id }, provider);
        }

        /// <summary>
        /// Delete a provider
        /// </summary>
        /// <returns>No Content if it was deleted correctly</returns>
        /// <param name="id">Id of the provider to delete</param>
        // DELETE: api/Providers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Provider>> DeleteProvider(int id)
        {
            if (!await providerDAO.DeleteAsync(id))
            {
                return StatusCode(providerDAO.customError.StatusCode, providerDAO.customError);
            }

            return NoContent();
        }
    }
}
