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
    public class IngridientsController : ControllerBase
    {
        private IRepository<Ingridients> _repo;

        public IngridientsController(IRepository<Ingridients> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("ingridient")]
        public List<Ingridients> GetAllCoffees()
        {
            List<Ingridients> ingirdientDb = _repo.ListCoffees();
            return ingirdientDb.ToList();
        }
    }
}
