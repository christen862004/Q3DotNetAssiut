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
    }
}
