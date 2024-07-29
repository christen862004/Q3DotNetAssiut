using Microsoft.AspNetCore.Mvc;
using Q3DotNetAssiut.Models;
using System.Diagnostics;

namespace Q3DotNetAssiut.Controllers
{
    public class HomeController : Controller
    {

        //MEthod Public 
        //Cant be static 
        //cant be overload
        //Home/ShowMsg
        public ContentResult ShowMsg()
        {
            //declare
            ContentResult result = new ContentResult();
            //initial
            result.Content = "HelloWolrd";
            //return 
            return result;
        }
        //Home/ShowView
        public ViewResult ShowView()
        {
            //logic
            ViewResult result = new ViewResult();
            //declare
            //initl
            result.ViewName = "View1";
            //return 
            return result;
        }
        //Home/ShowMix?id=1&name=ahmed
        public IActionResult ShowMix(int id,string name)
        {
            if (id % 2 == 0)
            {   
                return View("View1");
            }
            else
            {
                return Content("Hello");
            }
        }
        
        //public ViewResult view(string viewName)
        //{
        //    ViewResult result = new ViewResult();
        //    //declare
        //    //initl
        //    result.ViewName =viewName;
        //    //return 
        //    return result;
        //}

        //Action Return type
        //String--> ContentREsult
        //View  -->ViewResult
        //Json  -->JSonResult
        //File  -->FileResult
        //notfound ->NotFoundREsult
        //unauthor ->UnAuthoriResult
        //....







        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
