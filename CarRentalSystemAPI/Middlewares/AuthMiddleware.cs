using CarRentalSystemAPI.Services;
using System.Security.Claims;

namespace CarRentalSystemAPI.Middlewares
{
    public class AuthMiddleware {
        private readonly RequestDelegate next;
        
        private readonly IUserService userService;

        public AuthMiddleware(RequestDelegate req, IUserService userService)
        {
            this.userService = userService; 
            this.next = req;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authHeader = context.Request.Headers.Authorization.ToString();

            if(authHeader != null)
            {




                //var claims = new Claim[]
                //{
                //    new Claim("")
                //}
            }

            await next(context);
        }
    }
}
