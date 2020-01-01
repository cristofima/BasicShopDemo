using System;

namespace BasicShopDemo.Api.Core.DTO.Responses
{
    public class LoginResponse : BaseResponse
    {
        public string token { get; protected set; }
        public DateTime expirationDate { get; protected set; }

        public LoginResponse(string token, string title, int status, DateTime expirationDate) : base(title, status)
        {
            this.token = token;
            this.expirationDate = expirationDate;
        }

        public override bool IsSuccess()
        {
            return true;
        }
    }
}
