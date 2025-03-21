using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace chatdemo.Controllers
{
    [Route("/")]
    public class AuthController : Controller
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                return Challenge(GitHubAuthenticationDefaults.AuthenticationScheme);
            }

            HttpContext.Response.Cookies.Append("githubchat_username", User.Identity.Name ?? "");
            HttpContext.SignInAsync(User);
            return Redirect("/");
        }
    }
}