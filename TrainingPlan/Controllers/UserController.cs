using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;

namespace TrainingPlan.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [Route("~/api/Login")]
        [HttpPost]
        public IActionResult Login([FromBody] Users user)
        {
            if (user == null) return BadRequest();

            var userServices = new UserServices();

            bool login = userServices.Login(user.Email, user.Password);

            if (login) return CreatedAtRoute("test", new { id = 1 }, null);

            return BadRequest();
        }
    }
}