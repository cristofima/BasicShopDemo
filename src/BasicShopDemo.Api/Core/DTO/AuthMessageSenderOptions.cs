namespace BasicShopDemo.Api.Core.DTO
{
    public class AuthMessageSenderOptions
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}
