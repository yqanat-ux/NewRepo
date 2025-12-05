using System.Diagnostics;
using Favbook.Models;
using Microsoft.AspNetCore.Mvc;
var	cookies	=	Context.Request.Cookies;
var	cookies	=	Context.Request.Cookies; @foreach	(var	c	in	cookies)
{
<li>@c.Key	:	@c.Value</li>
}
<li	class="nav-item">
<a	class="nav-link	text-dark"	asp-area=""	asp-
controller=“Account"	asp-action=“Index">User	Account</a>
</li>

namespace Favbook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
public	IActionResult	SetCookies(string  cookie  ame,  string	cookieValue)
{
CookieOptions	options	= new	CookieOptions	{
Expires = DateTime. ow.AddDays(15),	// Cookie expires	in 14	days
HttpOnly	=	true, to the cookies
Secure  =	true,
SameSite	=	SameSiteMode.Strict
};
Response.Cookies.Append(cookie	آName,	cookieValue,	options); return	Ok("Cookies	has been	set.");
}
public	IActionResult	Index()
{
//	Check	if	the	user	is	authenticated
if	(User.Identity.IsAuthenticated){
//	User	is	logged	in,	get	their	username
SetCookies("userName",	User.Identity.	Name);
}
else{
//	User	is	not	logged	in,	set	a	cookie	with	"Guest" SetCookies("userName",		"guest");
}
SetCookies("broswerName",	Request.Headers["User-Agent"].ToString()); return	View();
}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

