﻿using BasicShopDemo.Api.Core.DTO;
using BasicShopDemo.Api.Core.Interfaces.DAO;
using BasicShopDemo.Api.Core.ModelBinder;
using BasicShopDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.Controllers
{
    /// <summary>
    /// Services to save, modify or delete product categories
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CategoriesController : ControllerBase
    {
        private ICategoryDAO categoryDAO;

        public CategoriesController(ICategoryDAO categoryDAO)
        {
            this.categoryDAO = categoryDAO;
        }

        /// <summary>
        /// Get all registered categories
        /// </summary>
        /// <returns>All Categories</returns>
        // GET: api/Categories
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult GetCategory([ModelBinder(typeof(QueryModelBinder))] Query query)
        {
            return Ok(categoryDAO.GetAll(query));
        }

        /// <summary>
        /// Get a category according to your Id
        /// </summary>
        /// <returns>Category data</returns>
        /// <param name="id">Category Id</param>
        // GET: api/Categories/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await categoryDAO.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        /// <summary>
        /// Modify a category
        /// </summary>
        /// <returns>No Content if it was modified correctly</returns>
        /// <param name="id">Category Id to Modify</param>
        /// <param name="category">Category data.</param>
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutCategory([FromRoute] int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            if (!await categoryDAO.UpdateAsync(category))
            {
                return StatusCode(categoryDAO.GetCustomError().StatusCode, categoryDAO.GetCustomError());
            }

            return NoContent();
        }

        /// <summary>
        /// Register a new product category
        /// </summary>
        /// <returns>The data of the added category</returns>
        /// <param name="category">Category data</param>
        // POST: api/Categories
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Category>> PostCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await categoryDAO.AddAsync(category))
            {
                return StatusCode(categoryDAO.GetCustomError().StatusCode, categoryDAO.GetCustomError());
            }

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        /// <summary>
        /// Delete a category
        /// </summary>
        /// <returns>No Content if it was deleted correctly</returns>
        /// <param name="id">Id of the category to delete</param>
        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Category>> DeleteCategory([FromRoute] int id)
        {
            if (!await categoryDAO.DeleteAsync(id))
            {
                return StatusCode(categoryDAO.GetCustomError().StatusCode, categoryDAO.GetCustomError());
            }

            return NoContent();
        }
    }
}