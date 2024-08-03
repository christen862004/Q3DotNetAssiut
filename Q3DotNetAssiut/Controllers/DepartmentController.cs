using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q3DotNetAssiut.Models;

namespace Q3DotNetAssiut.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Department> departmentList = 
                context.Department.Include(d=>d.Emps)
                .ToList();
            return View("Index",departmentList);//Model List<department>
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");//Model Null
        }

        //Department/SAveAdd? Name = Sd & ManagerName = Ahmed
        //GEt Handel
        //Post HAndel
        [HttpPost]//Fillter
        public IActionResult SAveAdd(Department newDeptFromRequest)
        {
            if (newDeptFromRequest.Name != null)
            {
                context.Department.Add(newDeptFromRequest);
                context.SaveChanges();
                //return View("Index",context.Department.ToList());
                //Call Action  from another action
                return RedirectToAction("Index");
            }
            return View("Add", newDeptFromRequest);//Model DEpartment
            
        }
    }
}
