using CoffeeVending.DataAccess;
using CoffeeVendingMachine.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeVendingMachineWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private IRepository<Coffee> _repo;

        public CoffeeController(IRepository<Coffee> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("coffee")]
        public List<Coffee> GetAllCoffees()
        {
            List<Coffee> coffeeDb = _repo.ListCoffees();
            return coffeeDb.ToList();
        }
    }
}
