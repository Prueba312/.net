using Fromend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static Fromend.Helper.Helper;
using Nancy.Json;
using System.Text;

namespace Fromend.Controllers
{
    public class HomeController : Controller
    {
        PersonaAPI _api = new PersonaAPI();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<personassccdata> personas = new List<personassccdata>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/PersonaObetener");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                personas = JsonConvert.DeserializeObject<List<personassccdata>>(results);
            }
            return View(personas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var persona = new personassccdata();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync($"api/Personadetalle/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                persona = JsonConvert.DeserializeObject<personassccdata>(results.Substring(1, results.Length-2));
            }
            return View(persona);
        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult create(personassccdata persona)
        {
            HttpClient client = _api.initial();

            //http post
            var json = new JavaScriptSerializer().Serialize(persona);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var posrtask = client.PostAsync("api/PersonaCrear", content);
            posrtask.Wait();

            var result = posrtask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var persona = new personassccdata();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync($"api/PersonaEliminar/{id}");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var persona = new personassccdata();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync($"api/Personadetalle/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                persona = JsonConvert.DeserializeObject<personassccdata>(results.Substring(1, results.Length - 2));
            }
            return View(persona);
        }

        [HttpPost]
        public IActionResult Edit(personassccdata persona)
        {
            HttpClient client = _api.initial();

            //http post
            var json = new JavaScriptSerializer().Serialize(persona);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var posrtask = client.PostAsync("api/PersonaEditar", content);
            posrtask.Wait();

            var result = posrtask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
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

        public ActionResult MaxCreate()
        {
            return View();
        }

        [HttpPost]

        public IActionResult MaxCreate(Archivodata Archvivo)
        {
            HttpClient client = _api.initial();

            //http post
            var json = new JavaScriptSerializer().Serialize(Archvivo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var posrtask = client.PostAsync("api/PersonaCrear", content);
            posrtask.Wait();

            var result = posrtask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
