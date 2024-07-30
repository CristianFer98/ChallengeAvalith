using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIMDP_APP.Models.Parking.Requests;
using MIMDP_APP.Models.Parking.Response;
using MIMDP_APP.Models.Parking.ViewModels;
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

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var parkingInfo = JsonConvert.DeserializeObject<ParkingInfoResponse>(jsonString);
                ParkingInfoViewModel parkingInfoViewModel = new ParkingInfoViewModel();
                parkingInfoViewModel.ParkingInfoResponse = parkingInfo;
                parkingInfoViewModel.NewParkingRequest = new NewParkingRequest();

                TempData["UserName"] = User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value;

                return View(parkingInfoViewModel);
            }
            TempData["Message"] = "El usuario no tiene cuenta en el portal";
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> NewParking(NewParkingRequest newParkingRequest)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(newParkingRequest);
                var request = new StringContent(json, Encoding.UTF8, "application/json");
                var token = Request.Cookies["AuthToken"];

                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var response = await _httpClient.PostAsync("https://localhost:44331/parking/NewParking", request);
                if (response.IsSuccessStatusCode)
                {
                   return RedirectToAction("Index");
                }

            }
            TempData["message"] = "Ha ocurrido un error";
            return RedirectToAction("Index");
        }


    }
}
