using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MShWeb.Application.Services.Helpers
{
    public static class HttpContextHelper
    {
        public static HttpContext? HttpContext => new HttpContextAccessor().HttpContext;
        public static IWebHostEnvironment Env => (IWebHostEnvironment)HttpContext.RequestServices.GetService(typeof(IWebHostEnvironment));

    }
}
