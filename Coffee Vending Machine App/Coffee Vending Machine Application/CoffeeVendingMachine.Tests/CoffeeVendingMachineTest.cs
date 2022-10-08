using CoffeeVendingMachine.Domain.Models;
using CoffeeVendingMachineWebApi.Controllers;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;

namespace CoffeeVendingMachine.Tests
{
    public class CoffeeVendingMachine
    {
        List<Coffee> coffees,coffeesdb;
        List<Ingridients> ingridients,ingridientsdb;
        [SetUp]
        public void Setup()
        {
            var client = new RestClient("http://localhost:16625/api/coffee/coffee");
            var request = new RestRequest("http://localhost:16625/api/coffee/coffee", Method.Get);
            RestResponse response = client.Execute(request);
            coffeesdb = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Coffee>>(response.Content);

            var clientI = new RestClient("http://localhost:16625/api/ingridients/ingridient");
            var requestI = new RestRequest("http://localhost:16625/api/ingridients/ingridient", Method.Get);

            RestResponse responseI = clientI.Execute(requestI);
            ingridientsdb = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ingridients>>(responseI.Content);

            coffees = new List<Coffee> {
                new Coffee
                {
                    Id = 1,
                    Name = "Latte",
                    Price = 5,
                    ImageLocation = "~/img/latte_01.jpg"
                },
                new Coffee
                {
                    Id = 2,
                    Name = "Macchiato",
                    Price = 6,
                    ImageLocation = "~/img/macchiato_01.jpg"
                },
                new Coffee
                {
                    Id = 3,
                    Name = "Esspresso",
                    Price = 4,
                    ImageLocation = "~/img/espresso_01.jpg"
                },
                new Coffee
                {
                    Id = 4,
                    Name = "Americano",
                    Price = 7,
                    ImageLocation = "~/img/americano_01.jpg"
                },
                new Coffee
                {
                    Id = 5,
                    Name = "Irish",
                    Price = 10,
                    ImageLocation = "~/img/irish_01.jpg"
                }
            };

            ingridients = new List<Ingridients> {
                new Ingridients
                {
                    Id = 1,
                    Name = "Sugar",
                    Price = 0
                },
                new Ingridients
                {
                    Id = 2,
                    Name = "Creamer",
                    Price = 2
                },
                new Ingridients
                {
                    Id = 3,
                    Name = "Caramelle",
                    Price = 3
                },
                new Ingridients
                {
                    Id = 4,
                    Name = "More milk",
                    Price = 4
                },
                new Ingridients
                {
                    Id = 5,
                    Name = "has a single dose of milk",
                    Price = 3
                },
                new Ingridients
                {
                    Id = 6,
                    Name = "one pack of sugar",
                    Price = 0
                }
        };
    }

        [Test]
        public void TestCoffees()
        {
            Assert.AreEqual(coffees, coffeesdb);
        }

        [Test]
        public void TestIngridients()
        {
            Assert.AreEqual(ingridients, ingridientsdb);
        }
    }
}