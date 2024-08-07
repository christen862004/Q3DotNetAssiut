using Microsoft.AspNetCore.Mvc;


namespace Q3DotNetAssiut.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IDepartmentRepository deptREpo;

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
