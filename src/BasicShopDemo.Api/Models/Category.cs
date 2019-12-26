using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicShopDemo.Api.Models
{
    /// <summary>
    /// Register the categories of products sold by the company
    /// </summary>
    [Table("Categories")]
    public class Category
    {
        /// <summary>
        /// Category Id
        /// </summary>
        /// <value>Id is automatically incremented</value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Get or set the category code
        /// </summary>
        /// <value>Category code</value>
        [Required]
        [Range(1, 999)]
        public int Code { get; set; }

        /// <summary>
        /// Get or set the category name
        /// </summary>
        /// <value>Category name</value>
        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        /// <summary>
        /// Get or set the category status (Active or Inactive)
        /// </summary>
        /// <value>Category status</value>
        public bool? Status { get; set; }

        /// <summary>
        /// Products list
        /// </summary>
        /// <value>Products</value>
        public virtual ICollection<Product> Products { get; set; }
    }
}