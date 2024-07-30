using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using MIMDP_APP.Models.Salud;
using MIMDP_APP.Models.Parking.Response;
using MIMDP_APP.Models.Parking.Requests;

namespace MIMDP_APP.Controllers
{
    public class SaludController : Controller
    {
        private readonly HttpClient _httpClient;


        public SaludController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Message = TempData["message"];
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(string NumeroDeTramite)
        {
            if (!string.IsNullOrEmpty(NumeroDeTramite))
            {
                var token = Request.Cookies["AuthToken"];

                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var request = new StringContent(JsonConvert.SerializeObject(NumeroDeTramite), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:44341/Salud/Info", request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var turnos = JsonConvert.DeserializeObject<List<Turno>>(jsonString);

                    SaludViewModel saludViewModel = new SaludViewModel();
                    saludViewModel.Turnos = turnos;
                    saludViewModel.Turno = new Turno();
                    TempData["UserName"] = User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value;

                    return View(saludViewModel);

                }
                else
                {
                    return BadRequest("Error en la solicitud: " + response.ReasonPhrase);
                }
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> NuevoTurno(SaludViewModel saludVieModel)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(saludVieModel.Turno);
                var request = new StringContent(json, Encoding.UTF8, "application/json");
                var token = Request.Cookies["AuthToken"];

                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var response = await _httpClient.PostAsync("https://localhost:44341/Salud/NuevoTurno", request);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Salud", new { saludVieModel.Turno.NumeroDeTramite });
                }

            }
            TempData["message"] = "Ha ocurrido un error";
            return RedirectToAction("Index");
        }

    }
}
