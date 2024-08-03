using Q3DotNetAssiut.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q3DotNetAssiut.ViewModel
{
    public class EmpWithDEptListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public string JobTitle { get; set; }

        public string ImageURL { get; set; }

        public string? Address { get; set; }


        public int DepartmentID { get; set; }

        public List<Department> DeptList { get; set; }
    }
}
