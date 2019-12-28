using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicShopDemo.Api.Models
{
    /// <summary>
	/// Register the providers categories
	/// </summary>
	[Table("ProvidersCategories")]
    public class ProviderCategory : Entity
    {
        /// <summary>
        /// Provider Id
        /// </summary>        
        [Required]
        public int ProviderId { get; set; }

        /// <summary>
        /// Category Id
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Provider Data
        /// </summary>
        public Provider Provider { get; set; }

        /// <summary>
        /// Category Data
        /// </summary>
        public Category Category { get; set; }
    }
}
