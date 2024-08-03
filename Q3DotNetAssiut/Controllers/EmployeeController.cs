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

        public IActionResult Index()
        {
            return View("Index", context.Employee.ToList());
        }

        //Hsandel Link
        public IActionResult Edit(int id)
        {
            Employee EmpModel =
                context.Employee.FirstOrDefault(e=>e.Id== id);
            List<Department> DepartmentList = context.Department.ToList();
            //-------------Create View Mode Mapping
            EmpWithDEptListViewModel EmpViewModel=new EmpWithDEptListViewModel();
            EmpViewModel.Id = EmpModel.Id;
            EmpViewModel.Name = EmpModel.Name;
            EmpViewModel.Address = EmpModel.Address;
            EmpViewModel.ImageURL = EmpModel.ImageURL;
            EmpViewModel.JobTitle = EmpModel.JobTitle;
            EmpViewModel.Salary = EmpModel.Salary; 
            EmpViewModel.DepartmentID = EmpModel.DepartmentID;

            EmpViewModel.DeptList = DepartmentList;

            return View("Edit", EmpViewModel);//Model EmpDeptListViewModel
        }
     
        [HttpPost]
        public IActionResult SaveEdit
            (int id,EmpWithDEptListViewModel EmpFromREquest)//Employee EmpFromREquest,int id)
        {
            if (EmpFromREquest.Name != null)
            {
                Employee EmpFromDB= context.Employee.FirstOrDefault(e => e.Id == id);
                EmpFromDB.Address=EmpFromREquest.Address;
                EmpFromDB.Name=EmpFromREquest.Name;
                EmpFromDB.Salary= EmpFromREquest.Salary;
                EmpFromDB.JobTitle= EmpFromREquest.JobTitle;
                EmpFromDB.ImageURL= EmpFromREquest.ImageURL;
                EmpFromDB.DepartmentID= EmpFromREquest.DepartmentID;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            //All Emp Data List<Department> 
            EmpFromREquest.DeptList = context.Department.ToList();
            return View("Edit", EmpFromREquest);
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
