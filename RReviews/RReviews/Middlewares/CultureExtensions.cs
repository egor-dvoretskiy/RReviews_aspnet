using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RReviews.Middlewares
{
    public static class CultureExtensions
    {
        public static IApplicationBuilder UseCustomCultureSettings(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }
    }
}
