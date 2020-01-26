using BasicShopDemo.Api.Core.DTO;
using BasicShopDemo.Api.Core.ModelBinder;
using BasicShopDemo.Api.DAO;
using BasicShopDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.Controllers
{
    /// <summary>
    /// Services to save, modify or delete products
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ProductsController : ControllerBase
    {
        private ProductDAO productDAO;

        public ProductsController(BasicShopContext context)
        {
            productDAO = new ProductDAO(context);
        }

        /// <summary>
        /// Get all registered products
        /// </summary>
        /// <returns>All Products</returns>
        // GET: api/Products
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult GetProduct([ModelBinder(typeof(QueryModelBinder))] Query query)
        {
            return Ok(productDAO.GetAll(query));
        }

        /// <summary>
        /// Get a Product according to your Id
        /// </summary>
        /// <returns>Product data</returns>
        /// <param name="id">Product Id</param>
        // GET: api/Products/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await productDAO.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Modify a Product
        /// </summary>
        /// <returns>No Content if it was modified correctly</returns>
        /// <param name="id">Product Id to Modify</param>
        /// <param name="product">Product data.</param>
        // PUT: api/Products/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            if (!await productDAO.UpdateAsync(product))
            {
                return StatusCode(productDAO.customError.StatusCode, productDAO.customError);
            }

            return NoContent();
        }

        /// <summary>
        /// Register a new product Product
        /// </summary>
        /// <returns>The data of the added Product</returns>
        /// <param name="product">Product data</param>
        // POST: api/Products
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await productDAO.AddAsync(product))
            {
                return StatusCode(productDAO.customError.StatusCode, productDAO.customError);
            }

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        /// <summary>
        /// Delete a Product
        /// </summary>
        /// <returns>No Content if it was deleted correctly</returns>
        /// <param name="id">Id of the Product to delete</param>
        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> DeleteProduct([FromRoute] int id)
        {
            if (!await productDAO.DeleteAsync(id))
            {
                return StatusCode(productDAO.customError.StatusCode, productDAO.customError);
            }

            return NoContent();
        }
    }
}