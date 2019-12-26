﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicShopDemo.Api.Models
{
    /// <summary>
    /// Register the products
    /// </summary>
    [Table("Products")]
    public class Product
    {
        /// <summary>
        /// Product Id
        /// </summary>
        /// <value>Id is automatically incremented</value>
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Get or set the product code
        /// </summary>
        /// <value>Product code</value>
        [Required]
        [Range(1, int.MaxValue)]
        public int Code { get; set; }

        /// <summary>
        /// Get or set the product name
        /// </summary>
        /// <value>Product name</value>
        [Required]
        [StringLength(70, MinimumLength = 3)]
        [Column(TypeName = "VARCHAR(70)")]
        public string Name { get; set; }

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