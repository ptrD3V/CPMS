using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CPMS.GUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CPMS.GUI.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginUser)
        {
            if (loginUser == null)
            {
                ViewData["Message"] = "User is not set.";
                return View();
            }

            DeveloperModel user;

            using (var client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(loginUser);
                    var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                    client.BaseAddress = new Uri("http://localhost:5000");
                    var response = await client.PostAsync($"/api/developer/authenticate", content);
                    if (!response.IsSuccessStatusCode)
                    {
                        ViewData["Message"] = "Bad name or password";
                        return View();
                    }
                    var result = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<DeveloperModel>(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName.ToString()));
            identity.AddClaim(new Claim("DisplayName", user.UserName));

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    IssuedUtc = DateTimeOffset.UtcNow,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                });
            return RedirectToLocal(string.Empty);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToLocal("/auth/login");
        }
    }
}