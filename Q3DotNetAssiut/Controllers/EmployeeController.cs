using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q3DotNetAssiut.Models;
using Q3DotNetAssiut.ViewModel;

namespace Q3DotNetAssiut.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public EmployeeController()
        {
                
        }
        public IActionResult Details(int id)
        {
            string msg = "Hello From Action";
            int temp = 50;
            List<string> bracnches= new List<string>();
            
            bracnches.Add("Assiut");
            bracnches.Add("Alex");
            bracnches.Add("Cario");
            //Aditional info send to View from Action
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["brch"] = bracnches;
            
           
            ViewData["Color"] = "Blue";
            ViewBag.Color = "REd";
            //ViewData.Model=empMo
            Employee EmpMOdel= context.Employee.FirstOrDefault(e => e.Id == id);
            return View("Details", EmpMOdel);
        }


        public IActionResult DetailsVM(int id)
        {
            Employee empMOdel= context.Employee
                .Include(e=>e.Department)
                .FirstOrDefault(e => e.Id == id);
            List<string> bracnches = new List<string>();

            bracnches.Add("Assiut");
            bracnches.Add("Alex");
            bracnches.Add("Cario");
            //decalre viewmode
            EmpDEptColorTempMSgBrchViewModel EmpVM = 
                new EmpDEptColorTempMSgBrchViewModel();
            //Mapping 
            EmpVM.EmpName = empMOdel.Name;
            EmpVM.DeptName = empMOdel.Department.Name;
            EmpVM.Color = "REd";
            EmpVM.Temp = 12;
            EmpVM.Msg = "Hello FRom VM";
            EmpVM.Branches = bracnches;
            return View("DetailsVM",EmpVM);//EmpDEptColorTempMSgBrchViewModel
        }
    }
}
