using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicShopDemo.Api.Models
{
    /// <summary>
    /// Register the API REST Logs
    /// </summary>
    [Table("Logs")]
    public class Log : Entity
    {
        [Required]
        public string Headers { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(10)")]
        public string Method { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Path { get; set; }

        public string QueryString { get; set; }

        public string RequestBody { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Host { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string ClientIp { get; set; }

        [Required]
        public int StatusCode { get; set; }

        [Required]
        public long ResponseTime { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
