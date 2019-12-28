using BasicShopDemo.Api.Validators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicShopDemo.Api.Models
{
	/// <summary>
	/// Register the providers
	/// </summary>
	[Table("Providers")]
	public class Provider : Entity
	{
		/// <summary>
		/// Provider RUC
		/// </summary>
		[Required]
		[Unique]
		[Column(TypeName = "VARCHAR(13)")]
		public string RUC { get; set; }

		/// <summary>
		/// Provider Business Name
		/// </summary>
		[Required]
		[StringLength(100, MinimumLength = 5)]
		[Unique]
		[Column(TypeName = "VARCHAR(100)")]
		public string BusinessName { get; set; }

		/// <summary>
		/// Provider address
		/// </summary>
		[Required]
		[StringLength(100, MinimumLength = 5)]
		[Column(TypeName = "VARCHAR(100)")]
		public string Address { get; set; }

		/// <summary>
		/// Provider email
		/// </summary>
		[MaxLength(50)]
		[EmailAddress]
		[Unique]
		[Column(TypeName = "VARCHAR(50)")]
		public string Email { get; set; }

		/// <summary>
		/// Provider phone
		/// </summary>
		[MaxLength(20)]
		[Phone]
		[Unique]
		[Column(TypeName = "VARCHAR(20)")]
		public string Phone { get; set; }

		/// <summary>
		/// Provider cellphone
		/// </summary>
		[MaxLength(10)]
		[Unique]
		[Column(TypeName = "VARCHAR(10)")]
		public string CellPhone { get; set; }

		/// <summary>
		/// Provider website
		/// </summary>
		[MaxLength(100)]
		[Url]
		[Unique]
		[Column(TypeName = "VARCHAR(100)")]
		public string WebSite { get; set; }

		/// <summary>
		/// Get or set the provider status (Active or Inactive)
		/// </summary>
		/// <value>Provider status</value>
		public bool? Status { get; set; }

		/// <summary>
		/// Provider Categories list
		/// </summary>
		/// <value>Provider Categories</value>
		public virtual ICollection<ProviderCategory> ProviderCategories { get; set; }
	}
}
