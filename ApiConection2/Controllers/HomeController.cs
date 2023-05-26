using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiConection2.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient httpClient;

        public HomeController()
        {
            httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7080/"); 

                var response = await client.GetAsync("/api/values");

                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadAsStringAsync();
                    ViewBag.Values = values.Split(',');
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddValue(string newValue)
        {
            var apiUrl = "https://localhost:7080/api/values"; 

            var content = new StringContent("\"" + newValue + "\"", Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(apiUrl, content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                // Aquí puedes agregar la lógica en caso de que la solicitud sea exitosa
            }
            else
            {
                Console.WriteLine(response);
                // Aquí puedes agregar la lógica en caso de que ocurra un error en la solicitud
            }

            return RedirectToAction("Index");
        }

    }
}
