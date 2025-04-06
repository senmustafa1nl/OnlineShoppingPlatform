using OnlineAlisverisPlatformu.Business.Operations.Setting;

namespace OnlineAlisverisPlatformu.WebApi.Middleware
{
    public class MaintenenceMiddleware
    {
        private readonly RequestDelegate _next;
      
        public MaintenenceMiddleware(RequestDelegate next)
        {
           
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var settingService = context.RequestServices.GetRequiredService<ISettingService>();

            bool maintenenceMode = settingService.GetMaintenenceState();


            if (context.Request.Path.StartsWithSegments("/api/settings") ||
                context.Request.Path.StartsWithSegments("/api/auth/login"))
            {
                await _next(context);
                return;
            }
            if (maintenenceMode)
            { await context.Response.WriteAsync("Site is under maintenence"); }
            else
            {
                await _next(context);
            }
        }
    }
}
