using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q3DotNetAssiut.Models;
using Q3DotNetAssiut.Repository;

namespace Q3DotNetAssiut.Controllers
{
    public class DepartmentController : Controller
    {
        // ITIContext context = new ITIContext();
        IDepartmentRepository DeptREpo;
        public DepartmentController(IDepartmentRepository deptRepo)///inject 
        {
            
            DeptREpo = deptRepo;// new DepartmentRepository();
            
        }
        [Authorize]
        public IActionResult Index()
        {
            List<Department> departmentList = DeptREpo.GetAll();
                //context.Department.Include(d=>d.Emps)
                //.ToList();
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
               DeptREpo.Add(newDeptFromRequest);
                DeptREpo.Save();
                return RedirectToAction("Index");
            }
            return View("Add", newDeptFromRequest);//Model DEpartment
            
        }
    }
}
