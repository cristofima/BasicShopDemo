using BasicShopDemo.Api.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicShopDemo.Api.Models
{
    /// <summary>
    /// Register the products
    /// </summary>
    [Table("Products")]
    public class Product : Entity
    {
        /// <summary>
        /// Get or set the category id
        /// </summary>
        /// <value>Category id</value>
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Get or set the product code
        /// </summary>
        /// <value>Product code</value>
        [Required]
        [Range(1, int.MaxValue)]
        [Unique]
        public int Code { get; set; }

        /// <summary>
        /// Get or set the product name
        /// </summary>
        /// <value>Product name</value>
        [Required]
        [StringLength(70, MinimumLength = 3)]
        [Unique]
        [Column(TypeName = "VARCHAR(70)")]
        public string Name { get; set; }

        /// <summary>
        /// Get or set the product price
        /// </summary>
        /// <value>Product price</value>
        [Required]
        [Range(0.05, 9999.99)]
        [Column(TypeName = "DECIMAL(6,2)")]
        public double Price { get; set; }

        /// <summary>
        /// Get or set the product status (Active or Inactive)
        /// </summary>
        /// <value>Product status</value>
        public bool? Status { get; set; }

        /// <summary>
        /// Product category
        /// </summary>
        /// <value>Category</value>
        public Category Category { get; set; }
    }
}