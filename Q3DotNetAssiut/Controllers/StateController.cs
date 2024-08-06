using Microsoft.AspNetCore.Mvc;

namespace Q3DotNetAssiut.Controllers
{
    public class StateController : Controller
    {
       public IActionResult SetSession(string name)
        {
            //logic
            HttpContext.Session.SetString("Name", name);
            //logic
            HttpContext.Session.SetInt32("Age", 21);
            return Content("Data Session Save Success");
        }

        public IActionResult GetSession()
        {
            //logic
            string n= HttpContext.Session.GetString("Name");
            int? a =  HttpContext.Session.GetInt32("Age");

            return Content($"name={n} \t age={a}");
        }

        public IActionResult SetCookie()
        {
            CookieOptions options=new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            //logic
            //Session Cookie
            HttpContext.Response.Cookies.Append("Name", "Ahmed");
            //Presisitent cookie
            HttpContext.Response.Cookies.Append("Age", "12", options);
            return Content("Cookie Save");
        }

        public IActionResult GetCookie()
        {
            string name= HttpContext.Request.Cookies["Name"];            
            string age = HttpContext.Request.Cookies["Age"];
            return Content($"name={name} \t age={age}");
        }
    }
}
