﻿using System.Collections.Generic;

namespace BasicShopDemo.Api.Core.DTO.Responses
{
    public class ErrorCRUDResponse : BaseResponse
    {
        public IEnumerable<Error> Errors { get; }

        public ErrorCRUDResponse(string title, int status, IEnumerable<Error> errors = null) : base(title, status)
        {
            if (errors == null)
            {
                errors = new List<Error>();
            }
            this.Errors = errors;
        }
    }
}
