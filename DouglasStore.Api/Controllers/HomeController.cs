using System;
using Microsoft.AspNetCore.Mvc;

namespace  DouglasStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        
        public object Get(){
            return new {Version = "Version 0.0.1"};
        }

        [HttpGet]
        [Route("error")]
        public string Error(){
            throw new Exception("Ocorreu um erro");
            return "erro";
        }
    }
}