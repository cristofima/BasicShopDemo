using System.ComponentModel.DataAnnotations;

namespace BasicShopDemo.Api.Models
{
    public class Entity
    {
        /// <summary>
        /// Entity Id
        /// </summary>
        /// <value>Id is automatically incremented</value>
        [Key]
        public int Id { get; set; }
    }
}
