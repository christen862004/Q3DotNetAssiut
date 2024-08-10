using Microsoft.AspNetCore.Mvc;

namespace Q3DotNetAssiut.Controllers
{
    public class RouteController : Controller
    {
        //Default route
        //Route/MEthod1?name=ahmed
        //R1/ahmed/12
        [Route("M1/{age:int}/{name?}",Name ="R1")]
        public IActionResult Method1()//string name,int age)
        {
            return Content("M1");
        }
        //R2
        public IActionResult Method2()
        {
            return Content("M2");
        }
        //R3
        public IActionResult Method3()
        {
            return Content("M2");
        }
    }
}
