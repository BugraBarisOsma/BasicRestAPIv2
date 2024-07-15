using BasicRestAPI.Services;
using BasicRestAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BasicRestAPI.Attributes;

public class AuthenticationAttribute : Attribute , IAuthorizationFilter
{
// Burada DI ile userService'i cagirmadik cunku attribute , controller'da bizden bir service isteyecektir. Bunu engellemek icin service 
// OnAuthorization methodu icerisinde cagirildi. Bu saglikli bir cozum degildir.
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var _userService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;
        if (_userService == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        var username = context.HttpContext.Request.Headers["Username"].FirstOrDefault();
        var password = context.HttpContext.Request.Headers["Password"].FirstOrDefault();

        if (username == null || password == null || _userService.ValidateUser(username, password) == null)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}