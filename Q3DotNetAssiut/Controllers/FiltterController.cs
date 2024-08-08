using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Q3DotNetAssiut.Controllers
{
    //  [HandelError]
//    [Authorize]
    public class FiltterController : Controller
    {
        //      [HandelError]
  //      [AllowAnonymous]
        public IActionResult Index()
        {
            throw new Exception("Exception Fr index");
        }
//        [HandelError]

        public IActionResult Index2()
        {
            throw new Exception("Exception Fr index");
        }
    }
}
