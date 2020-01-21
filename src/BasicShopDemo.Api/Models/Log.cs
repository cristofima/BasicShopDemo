using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        [Column("Headers")]
        [JsonIgnore]
        public string _headers { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(10)")]
        public string Method { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Path { get; set; }

        public string QueryString { get; set; }

        [Column("RequestBody")]
        [JsonIgnore]
        public string _requestBody { get; set; }

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

        [NotMapped]
        public JObject Headers
        {
            get
            {
                return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(_headers) ? "{}" : _headers);
            }
        }

        [NotMapped]
        public JObject RequestBody
        {
            get
            {
                return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(_requestBody) ? "{}" : _requestBody);
            }
        }
    }
}
