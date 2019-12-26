using System.Collections.Generic;

namespace BasicShopDemo.Api.Core
{
    /// <summary>
    /// Error messages
    /// </summary>
    public class CustomError
    {
        /// <summary>
        /// Error code
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Errors list
        /// </summary>
        public Dictionary<string, List<string>> Errors { get; }

        /// <param name="statusCode">Error code</param>
        /// <param name="errors">Errors list</param>
        public CustomError(int statusCode, Dictionary<string, List<string>> errors)
        {
            StatusCode = statusCode;
            Errors = errors;

            if (errors != null && errors.Count > 0)
            {
                Message = "One or more validation errors occurred.";
            }
        }
    }
}