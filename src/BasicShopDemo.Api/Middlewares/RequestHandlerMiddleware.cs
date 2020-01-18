using BasicShopDemo.Api.Data;
using BasicShopDemo.Api.Models;
using BasicShopDemo.Api.Utils;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.Middlewares
{
    public class RequestHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public RequestHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ApplicationDbContext dbDontext)
        {
            if (!context.Request.Path.ToString().StartsWith("/api"))
            {
                await next(context);

                return;
            }

            string headers = JsonConvert.SerializeObject(context.Request.Headers);

            var log = new Log
            {
                Headers = headers,
                Method = context.Request.Method,
                Path = context.Request.Path,
                QueryString = context.Request.QueryString.Value,
                Host = context.Request.Host.Host,
                ClientIp = context.Connection.RemoteIpAddress.ToString(),
                TransactionDate = DateUtils.GetCurrentDate()
            };

            context.Request.EnableBuffering();

            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();

            log.RequestBody = body.ToString();
            context.Request.Body.Position = 0;

            var watch = Stopwatch.StartNew();

            await next(context);

            watch.Stop();

            log.ResponseTime = watch.ElapsedMilliseconds;
            log.StatusCode = context.Response.StatusCode;

            dbDontext.Log.Add(log);
            await dbDontext.SaveChangesAsync();
        }
    }
}
