using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Q3DotNetAssiut.Models;
using Q3DotNetAssiut.Repository;
using Q3DotNetAssiut.ViewModel;

namespace Q3DotNetAssiut.Controllers
{
    public class EmployeeController : Controller
    {
        //  ITIContext context = new ITIContext();
        IDepartmentRepository DepartmentRepository;
        IEmployeeRepository EmployeeRepository;
        public EmployeeController(IDepartmentRepository deptReo, IEmployeeRepository EmpRepo)
        {
            DepartmentRepository = deptReo;
            EmployeeRepository = EmpRepo;
        }
        //Employee/CheckSalary?Salary=1000
        public IActionResult CheckSalary(int Salary,string JobTitle)
        {
            if (Salary > 6000 && JobTitle =="S")
                return Json(true);
            else if(JobTitle=="B" && Salary>10000)
                return Json(true);
            else if(JobTitle=="M" && Salary>40000)
                return Json(true);
            else
                return Json(false);
        }


        [HttpGet]
        public IActionResult NEw()
        {
            ViewData["DeptList"] =DepartmentRepository.GetAll();
            return View("New");
        }

        [HttpPost]
        public IActionResult SaveNEw(Employee EmpFromREquest)
        {
            if(ModelState.IsValid==true)
            {
                try
                {
                    //save
                    EmployeeRepository.Add(EmpFromREquest);
                    EmployeeRepository.Save();
                    return RedirectToAction("Index");
                }catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
            }
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View("NEw", EmpFromREquest);
        }



        public IActionResult Index()
        {
            return View("Index",EmployeeRepository.GetAll());
        }

        //Hsandel Link
        public IActionResult Edit(int id,string name)
        {
            Employee EmpModel =
              EmployeeRepository.GetById(id);
            List<Department> DepartmentList = DepartmentRepository.GetAll();
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
                Employee EmpFromDB = EmployeeRepository.GetById(id);//context.Employee.FirstOrDefault(e => e.Id == id);
                EmpFromDB.Address=EmpFromREquest.Address;
                EmpFromDB.Name=EmpFromREquest.Name;
                EmpFromDB.Salary= EmpFromREquest.Salary;
                EmpFromDB.JobTitle= EmpFromREquest.JobTitle;
                EmpFromDB.ImageURL= EmpFromREquest.ImageURL;
                EmpFromDB.DepartmentID= EmpFromREquest.DepartmentID;
                EmpFromDB.Id= EmpFromREquest.Id;
                EmployeeRepository.Update(EmpFromDB);
                EmployeeRepository.Save();
                //context.SaveChanges();
                return RedirectToAction("Index");
            }
            //All Emp Data List<Department> 
            EmpFromREquest.DeptList = DepartmentRepository.GetAll();//context.Department.ToList();
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
            Employee EmpMOdel = EmployeeRepository.GetById(id);// context.Employee.FirstOrDefault(e => e.Id == id);
            return View("Details", EmpMOdel);
        }


        public IActionResult DetailsVM(int id)
        {
            Employee empMOdel = EmployeeRepository.GetById(id);
                
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
