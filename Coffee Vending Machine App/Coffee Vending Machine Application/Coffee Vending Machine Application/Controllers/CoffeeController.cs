using Coffee_Vending_Machine_Application.Models;
using CoffeeVending.DataAccess;
using CoffeeVendingMachine.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System.Collections.Generic;
using System.Diagnostics;

namespace Coffee_Vending_Machine_Application.Controllers
{
    public class CoffeeController : Controller
    {
        private readonly ILogger<CoffeeController> _logger;
        private IRepository<Coffee> _repo;

        public CoffeeController(ILogger<CoffeeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var client = new RestClient("http://localhost:16625/coffee/coffee");
            var request = new RestRequest("http://localhost:16625/coffee/coffee", Method.Get);
            RestResponse response = client.Execute(request);
            List<Coffee> coffee = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Coffee>>(response.Content);
            return View(coffee);
        }

        public IActionResult Order()
        {
            var client = new RestClient("http://localhost:16625/coffee/coffee");
            var request = new RestRequest("http://localhost:16625/coffee/coffee", Method.Get);

            RestResponse response = client.Execute(request);
            List<Coffee> coffee = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Coffee>>(response.Content);

            ViewBag.Coffee = coffee;


            var clientI = new RestClient("http://localhost:16625/ingridients/ingridient");
            var requestI = new RestRequest("http://localhost:16625/ingridients/ingridient", Method.Get);

            RestResponse responseI = clientI.Execute(requestI);
            List<Ingridients> ingridient = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ingridients>>(responseI.Content);

            ViewBag.Ingridient = ingridient;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
