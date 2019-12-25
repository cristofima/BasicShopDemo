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
        /// Field with error
        /// </summary>
        public string Field { get; }

        /// <param name="statusCode">Error code</param>
        /// <param name="message">Message explaining the error</param>
        /// <param name="field">Field with error</param>
        public CustomError(int statusCode, string message, string field)
        {
            StatusCode = statusCode;
            Message = message;
            Field = field;
        }

    }
}
