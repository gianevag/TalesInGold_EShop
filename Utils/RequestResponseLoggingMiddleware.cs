using System;
using System.IO;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace TalesInGold_EShop
{
    public class RequestResponseLoggingMiddleware
    {
        private string PathFormat = "logs/TIG.log";
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next,
                                                ILoggerFactory loggerFactory,
                                                IHostingEnvironment env)
        {
            if (!env.IsDevelopment()){
                PathFormat = "logs/TIG/TIG.log";
            }

            loggerFactory.AddFile(PathFormat);
            _next = next;
            _logger = loggerFactory
                      .CreateLogger<RequestResponseLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            
            _logger.LogInformation(await FormatRequest(context.Request));

            await _next(context);

        }
        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;
            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;

            return $"REQUEST {DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff")} {request.HttpContext.Connection.RemoteIpAddress } {request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

    }

}
