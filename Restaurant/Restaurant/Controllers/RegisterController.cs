using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        Repository repo = new Repository();
        [HttpPost]
        [Route("register")]
        public void Register(string Name, string Email, string Password)
        {
            Int64 key = Encription.Generate_Key();
            repo.Sign_Up(Name, "Waiter", Email, key, Encription.EncryptPassword(key, Password));
        }
        [Route("login")]
        public long LogIn(string email, string password)
        {
            return repo.Log_In(email, Encription.EncryptPassword(repo.Get_Key(email), password));
        }
    }
}
