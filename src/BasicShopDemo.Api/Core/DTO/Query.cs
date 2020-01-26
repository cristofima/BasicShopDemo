namespace BasicShopDemo.Api.Core.DTO
{
    public class Query
    {
        public uint? Skip { get; set; }
        public uint? Take { get; set; }
        public string Filter { get; set; }
    }
}
