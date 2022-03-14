using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APITestWebApp.Models;
using APITestWebApp.Helper;
using DomainLayer.Model;
using System.Net.Http;
using Newtonsoft.Json;
using RepositoryLayer;


namespace APITestWebApp.Controllers
{
    public class HomeController : Controller
    {

        UserAPI _api = new UserAPI();

        public async Task<IActionResult> Index() {

            List<User> user = new List<User>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/User/getall");
            if (res.IsSuccessStatusCode) {
                var result = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List<User>>(result);
            }
            return View(user);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = new User();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/User/get/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(result);
            }
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<User>("api/User/add", user);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode) {

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = new User();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/User/delete/{id}");
            return RedirectToAction("Index");
        }











        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
    }
}
