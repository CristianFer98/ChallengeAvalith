using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIMDP_APP.Models.Parking.Requests;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MyAppMVC.Controllers
{
    [Authorize]
    public class ParkingController : Controller
    {
        private readonly HttpClient _httpClient;

        public ParkingController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            ParkingInfoRequest parkingInfoRequest = new ParkingInfoRequest()
            {
                Dni = User.Claims.FirstOrDefault(c => c.Type == "Dni")?.Value,
                UserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value)
            };

            var json = JsonConvert.SerializeObject(parkingInfoRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var token = Request.Cookies["AuthToken"];

            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _httpClient.PostAsync("https://localhost:44331/parking/info", content);
            var jsonString = await response.Content.ReadAsStringAsync();

            var parkingInfo = JsonConvert.DeserializeObject<ParkingInfoResponse>(jsonString);
            TempData["UserName"] = User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value;
            return View(parkingInfo);
        }
    }
}
