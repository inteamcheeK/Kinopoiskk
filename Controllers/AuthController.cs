using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Kinopoiskk.Controllers;

public class AuthController : Controller


{

    private readonly DataContext dbContext;
    
    public AuthController (DataContext dataContext)
    {
        this.dbContext = dataContext;
    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]

    public IActionResult SendRegister(User users)
    {
        users.Name = "testName";
        users.PhoneNumber = "1234567";
        dbContext.Users.Add(users);
        dbContext.SaveChanges();

        List<Claim> claims = new List<Claim>()
        { 
            new Claim(ClaimTypes.NameIdentifier, users.Email),
            new Claim("OtherProperties","Example Role")
        };

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        AuthenticationProperties properties = new AuthenticationProperties()
        { 
            AllowRefresh = true,
            IsPersistent = true
        };

        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
        return RedirectToAction("Index", "Movie");
    }

        public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public IActionResult SendLogin(User users)
    {
        var user = dbContext.Users.FirstOrDefault(a => a.Email == users.Email && a.Password == users.Password);
        
        List<Claim> claims = new List<Claim>()
        { 
            new Claim(ClaimTypes.Email, users.Email),
            new Claim("OtherProperties","Example Role")
        };

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        AuthenticationProperties properties = new AuthenticationProperties()
        { 
            AllowRefresh = true,
            IsPersistent = true
        };

        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

        return RedirectToAction("Index", "User");
    }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
}
