using System.Collections.Generic;

namespace BasicShopDemo.Api.Core.DTO.Responses
{
    public class SuccessResponse : BaseResponse
    {
        public IEnumerable<Error> Errors { get; }

        public SuccessResponse(string title, int status, IEnumerable<Error> errors = null) : base(title, status)
        {
            if (errors == null)
            {
                errors = new List<Error>();
            }
            this.Errors = errors;
        }

        public override bool IsSuccess()
        {
            return this.Errors == null;
        }
    }
}
