using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIMDP_APP.Models.Parking;
using MIMDP_APP.Models.Parking.Requests;
using MIMDP_APP.Models.Parking.Response;
using MIMDP_APP.Models.Parking.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            string DNI = User.Claims.FirstOrDefault(c => c.Type == "Dni")?.Value;

            List<Autos> autos = await GetAutos(DNI);
            List<Parking> parkings = await GetParkings(DNI);

            ParkingIndexViewModel parkingIndexViewModel = new ParkingIndexViewModel();

            parkingIndexViewModel.Parkings = parkings;
            parkingIndexViewModel.Autos = autos;
            parkingIndexViewModel.NuevoParking = new NuevoParking();
            TempData["UserName"] = User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value;

            return View(parkingIndexViewModel);
        }

        private async Task<List<Parking>> GetParkings(string DNI)
        {
            try
            {
                var json = JsonConvert.SerializeObject(DNI);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var token = Request.Cookies["AuthToken"];

                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var response = await _httpClient.PostAsync("https://localhost:44331/parking/parkings", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    List<Parking> parkings = JsonConvert.DeserializeObject<List<Parking>>(jsonString);

                    return parkings;
                }
                return new List<Parking>();
            }
            catch (Exception)
            {
                return new List<Parking>();
            }
        }

        private async Task<List<Autos>> GetAutos(string DNI)
        {
            try
            {
                var json = JsonConvert.SerializeObject(DNI);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var token = Request.Cookies["AuthToken"];

                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var response = await _httpClient.PostAsync("https://localhost:44331/Parking/Autos", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    List<Autos> autos = JsonConvert.DeserializeObject<List<Autos>>(jsonString);

                    return autos;
                }
                return new List<Autos>();
            }
            catch (Exception)
            {
                return new List<Autos>();
            }
        }

        [Authorize]
        public async Task<IActionResult> NuevoParking(NuevoParking nuevoParking)
        {
            if (ModelState.IsValid)
            {
                nuevoParking.IdUsuario = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value);

                var json = JsonConvert.SerializeObject(nuevoParking);
                var request = new StringContent(json, Encoding.UTF8, "application/json");
                var token = Request.Cookies["AuthToken"];

                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var response = await _httpClient.PostAsync("https://localhost:44331/parking/nuevo", request);
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
