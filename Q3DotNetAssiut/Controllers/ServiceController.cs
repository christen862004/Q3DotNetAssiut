using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using System.Security.Claims;


namespace Q3DotNetAssiut.Controllers
{
    public class ServiceController : Controller
    {
        //Serivce/add
        [HttpGet]
        public IActionResult add()
        {
            return Content("add Get");
        }
        [HttpPost]
        //Service/add?ss=11
        public IActionResult add(string ss)
        {
            return Content("add 2");
        }

        private readonly IDepartmentRepository deptREpo;
        //[Authorize]
        public IActionResult TestAuth()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                
                Claim IDClaim= User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                Claim AddressClaim = User.Claims.FirstOrDefault(c => c.Type == "UserAddress");

                string id = IDClaim.Value;

                string name = User.Identity.Name;
                return Content($"welcome {name} \n ID= {id}");
            }
            return Content("Welcome Guest");
        }





        public ServiceController(IDepartmentRepository deptREpo)
        {
            this.deptREpo = deptREpo;
        }

        public IActionResult Index(int id)//[FromServices]IDepartmentRepository deptrr)
        {
            ViewBag.Id = deptREpo.Id;
            return View("Index");
        }
    }
}
