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
using MIMDP_APP.Models.Parking;
using System;
using MIMDP_APP.Models;
using MIMDP_APP.Models.Salud.request;
using MIMDP_APP.Models.Salud.ViewModels;

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
            TempData["UserName"] = User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Index(AccesRequest accesRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    accesRequest.DNI = User.Claims.FirstOrDefault(c => c.Type == "Dni")?.Value;
                    SaludIndexViewModel saludIndexViewModel = IndexInformation(accesRequest);

                    if (saludIndexViewModel != null)
                    {
                        TempData["UserName"] = User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value;
                        return View(saludIndexViewModel);
                    }
                    TempData["message"] = "El Numero de Tramite no concuerda con el usuario logueado";
                    return RedirectToAction("Form");

                }
                catch (Exception ex)
                {
                    TempData["message"] = ex.Message;
                    return RedirectToAction("Form");
                }
            }
            TempData["message"] = "Dato incorrecto";
            return RedirectToAction("Form");

        }

        [Authorize]
        [HttpGet]
        public IActionResult Index(string NumeroDeTramite)
        {
            if (!string.IsNullOrEmpty(NumeroDeTramite))
            {
                string Dni = User.Claims.FirstOrDefault(c => c.Type == "Dni")?.Value;
                AccesRequest accesRequest = new AccesRequest();
                accesRequest.DNI = Dni;
                accesRequest.NumeroDeTramite = NumeroDeTramite;
                SaludIndexViewModel saludIndexViewModel = IndexInformation(accesRequest);

                ViewBag.Message = TempData["message"];
                TempData["UserName"] = User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value;
                return View(saludIndexViewModel);
            }
            TempData["message"] = "Se ha de proporcionar un numero de tramite";
            return RedirectToAction("Form");
        }

        private SaludIndexViewModel IndexInformation(AccesRequest accesRequest)
        {
            try
            {
                List<CentroDeSalud> centroDeSalud = GetCentrosDeSalud();
                List<Turnos> turnos = GetTurnos(accesRequest);
                List<Especialidad> especialidades = GetEspecialidades();

                if (turnos == null)
                {
                    return null;
                }

                SaludIndexViewModel saludIndexViewModel = new SaludIndexViewModel();

                saludIndexViewModel.Turnos = turnos;
                saludIndexViewModel.CentrosDeSalud = centroDeSalud;
                saludIndexViewModel.Espacialidades = especialidades;
                saludIndexViewModel.Turno = new Turnos();


                return saludIndexViewModel;
            }
            catch (Exception)
            {
                return null;
            }

        }

        private List<CentroDeSalud> GetCentrosDeSalud()
        {
            try
            {
                var token = Request.Cookies["AuthToken"];

                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var response = _httpClient.GetAsync("https://localhost:44341/Salud/CentrosSalud").GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    List<CentroDeSalud> centrosDeSalud = JsonConvert.DeserializeObject<List<CentroDeSalud>>(jsonString);

                    return centrosDeSalud;
                }
                return new List<CentroDeSalud>();
            }
            catch (Exception)
            {
                return new List<CentroDeSalud>();
            }
        }

        private List<Especialidad> GetEspecialidades()
        {
            try
            {
                var token = Request.Cookies["AuthToken"];

                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var response = _httpClient.GetAsync("https://localhost:44341/Salud/Especialidades").GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    List<Especialidad> especialidades = JsonConvert.DeserializeObject<List<Especialidad>>(jsonString);

                    return especialidades;
                }
                return new List<Especialidad>();
            }
            catch (Exception)
            {
                return new List<Especialidad>();
            }
        }

        private List<Turnos> GetTurnos(AccesRequest accesRequest)
        {
            try
            {
                var json = JsonConvert.SerializeObject(accesRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var token = Request.Cookies["AuthToken"];

                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var response = _httpClient.PostAsync("https://localhost:44341/Salud/Turnos", content).GetAwaiter().GetResult(); ;

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    List<Turnos> turnos = JsonConvert.DeserializeObject<List<Turnos>>(jsonString);

                    return turnos;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> NuevoTurno(SaludIndexViewModel saludViewModel)
        {
            string numeroDeTramite = saludViewModel.NumeroDeTramite;

            if (ModelState.IsValid)
            {
                Turnos turno = saludViewModel.Turno;
                turno.IdUsuario = saludViewModel.UserId;

                var json = JsonConvert.SerializeObject(turno);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var token = Request.Cookies["AuthToken"];

                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var response = await _httpClient.PostAsync("https://localhost:44341/Salud/NuevoTurno", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { NumeroDeTramite = numeroDeTramite });
                }
                return RedirectToAction("Index", new { NumeroDeTramite = numeroDeTramite });
            }
            TempData["message"] = "Ingresar una fecha a partir de mañana";
            return RedirectToAction("Index", new { NumeroDeTramite = numeroDeTramite });
        }
    }
}
