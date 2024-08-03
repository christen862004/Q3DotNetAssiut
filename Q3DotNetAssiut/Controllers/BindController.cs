using Microsoft.AspNetCore.Mvc;
using Q3DotNetAssiut.Migrations;
using Q3DotNetAssiut.Models;

namespace Q3DotNetAssiut.Controllers
{
    public class BindController : Controller
    {
        //REquest Html (data)
        //Binding Prmitive (int ,string ...
        //Bind/TestPrmitive?name=ahmed&age=12&id=10&Color=red&color=blue
        //Bind/TestPrmitive/10?name=ahmed&age=12   [RouteValues]


        //<form action= "Bind/TestPrmitive" method="get">
        //    <input type="text" name="name">
        //    <input type = "text" name="age">

        public IActionResult TestPrmitive
            (string name,int id,string[] color,int age)
        {
            return Content($"{name} \t {age}");
        }

        //Bind Collection
        //Bind/TestDic?name=alaa&Phones[Ahmed]=123&phones[chris]=456
        public IActionResult TestDic(Dictionary<string,string> Phones,string name) {
            return Content("Ok");
        }

        //Bind/TestObj?id=1&naMe=Sd&managername=AbdelRahman&color=red
        //Bind/TestObj/1?naMe=Sd&managername=AbdelRahman&color=red&emps[0].NAme=Mohamed

        public IActionResult testObj(Department deptObj,string name)
        {
            return Content("Obj");
        }
    }
}
