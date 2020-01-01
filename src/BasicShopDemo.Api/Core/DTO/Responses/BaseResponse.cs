namespace BasicShopDemo.Api.Core.DTO.Responses
{
    public class BaseResponse
    {
        public string title { get; protected set; }
        public int status { get; protected set; }

        public BaseResponse(string title, int status)
        {
            this.title = title;
            this.status = status;
        }

        public virtual bool IsSuccess()
        {
            return false;
        }
    }
}
