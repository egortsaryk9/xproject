using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost("session")]
        public JsonResult GetSession([FromBody] LoginModel model)
        {
            if (model.Email == "egortsaryk@gmail.com" && model.Password == "qwerty")
                return Json(new {success = true, auth_token = "chwdunc48904982fjeklcm432423freepfferj"});

            return Json(new {success = false});
        }
    }

    public class LoginModel 
    {
        public string Email {get; set;}
        public string Password {get; set;}
    }
}