using FinalProject.UI;
using FinalProject.UI.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class AccountController : Controller
{
    private readonly IConfiguration _configuration;

    // Dictionary to hold users loaded from config
    public Dictionary<string, UserDetails> Users { get; }

    public AccountController(IConfiguration configuration)
    {
        _configuration = configuration;

        // Manually parse the "Users" section into a dictionary
        Users = new Dictionary<string, UserDetails>();
        var usersSection = _configuration.GetSection("UsersDetail");

        foreach (var child in usersSection.GetChildren())
        {
            var userKey = child.Key;
            var userDetails = child.Get<UserDetails>();
            Users[userKey] = userDetails;
        }
    }

    // GET: /Account/Login
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    // POST: /Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Check if username exists in the dictionary
            if (Users.ContainsKey(model.Username))
            {
                var user = Users[model.Username];

                // Validate password
                if (model.Password == user.Password)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username)
                };

                    // Add each role as a separate claim
                    foreach (var role in user.Roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    // Sign in the user
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    // Redirect to home page on successful login
                    return RedirectToAction("Index", "Home");
                }
            }

            // If we reach here, login failed
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        // If model validation failed or login failed, return the view with model errors
        return View(model);
    }


    // POST: /Account/Logout
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        // Sign out the user
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        // Redirect to login page after logout
        return RedirectToAction("Login");
    }
}
