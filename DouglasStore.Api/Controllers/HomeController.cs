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
    }
}