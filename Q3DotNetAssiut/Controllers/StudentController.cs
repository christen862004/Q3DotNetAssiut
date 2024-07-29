using Microsoft.AspNetCore.Mvc;
using Q3DotNetAssiut.Models;

namespace Q3DotNetAssiut.Controllers
{
    public class StudentController : Controller
    {
       //Student/ShowAll
       public IActionResult ShowAll()
        {
            StudentBL studentBL = new StudentBL();
            List<Student> StudentListModel = studentBL.GetAll();//
            return View("ShowAll",StudentListModel);//Moedl List<student>
        }

        //Student/DEtails?id=1
        public IActionResult DEtails(int id)
        {
            StudentBL studentBL = new StudentBL();

            Student studentModel = studentBL.GetById(id);
            return View("ShowDEtails",studentModel);//View ShowDetails ==Model Student
        }
    }
}
