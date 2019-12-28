using BasicShopDemo.Api.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;

namespace BasicShopDemo.Api.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilter(IHostingEnvironment hostingEnvironment, IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.InnerException != null && context.Exception.InnerException.GetType() == typeof(SqlException))
            {
                var exSQLServer = (SqlException)context.Exception.InnerException;
                var mySqlCustomError = new CustomSQLServerException();

                var table = context.RouteData.Values["controller"].ToString();
                var errorMessage = mySqlCustomError.ShowSQLServerError(exSQLServer, table, this.GetType().Name);

                var badRequest = new BadRequestObjectResult(new { status = 400, message = errorMessage });
                context.Result = badRequest;
            }
            else
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
