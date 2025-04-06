namespace OnlineAlisverisPlatformu.WebApi.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMaintenenceMode(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MaintenenceMiddleware>();
        }
    }
}
