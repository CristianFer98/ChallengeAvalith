using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAppMVC.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace MyAppMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.Message = TempData["message"];
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterData user)
        {

            if (!ModelState.IsValid)
            {
                TempData["message"] = "Datos Incorrectos";
                return View();
            }
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var newUser = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost:36521/authentication/register", newUser);

                TempData["message"] = await response.Content.ReadAsStringAsync();
                return RedirectToAction("Register");

            }
            catch (System.Exception)
            {
                TempData["message"] = "Ha ocurrido un error inesperado";
                return RedirectToAction("Register");
            }
        }


        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Message = TempData["message"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginData user)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = "Datos Incorrectos";
                return View();
            }

            try
            {
                var json = JsonConvert.SerializeObject(user);
                var dataUser = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost:36521/authentication/login", dataUser);
                var Jwt = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    TempData["message"] = Jwt;
                    RedirectToAction("Login");
                }

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,    
                    Expires = DateTime.UtcNow.AddHours(1) 
                };

                Response.Cookies.Append("AuthToken", Jwt, cookieOptions);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies.Append("AuthToken", "", new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(-1),
                    HttpOnly = true,
                    Secure = true
                });
            }
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}
