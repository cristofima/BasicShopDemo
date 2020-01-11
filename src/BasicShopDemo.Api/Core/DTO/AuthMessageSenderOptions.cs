namespace BasicShopDemo.Api.Core.DTO
{
    public class AuthMessageSenderOptions
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
    }
}
