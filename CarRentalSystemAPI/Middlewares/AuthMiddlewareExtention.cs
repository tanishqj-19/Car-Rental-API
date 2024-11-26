namespace CarRentalSystemAPI.Middlewares
{
    public static class AuthMiddlewareExtention
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
