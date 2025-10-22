using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomAuthorizationAttribute : ActionFilterAttribute
{
    private readonly string _requiredRole;

    public CustomAuthorizationAttribute(string requiredRole)
    {
        _requiredRole = requiredRole;
    }

    public CustomAuthorizationAttribute()
    {
        _requiredRole = null;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userId = context.HttpContext.Session.GetString("UserId");
        var userRole = context.HttpContext.Session.GetString("UserRole");

        if (string.IsNullOrEmpty(userId))
        {
            var redirectRole = _requiredRole ?? "Lecturer";
            context.Result = new RedirectToActionResult("Login", "Account", new { role = redirectRole });
            return;
        }

        if (_requiredRole != null && userRole != _requiredRole)
        {
            context.Result = new RedirectToActionResult("AccessDenied", "Home", null);
            return;
        }

        base.OnActionExecuting(context);
    }
}