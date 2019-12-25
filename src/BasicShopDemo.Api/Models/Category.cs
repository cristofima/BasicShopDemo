using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicShopDemo.Api.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 999)]
        public int Code { get; set; }

        [StringLength(80)]
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Name { get; set; }
    }
}