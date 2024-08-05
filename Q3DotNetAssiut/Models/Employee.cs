using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q3DotNetAssiut.Models
{
    public class Employee
    {
        public int Id { get; set; }

        //        [Required]
        [MinLength(2,ErrorMessage ="Name Must be greater than 2 char")]
        [MaxLength(25)]
        [Unique]
        public string Name { get; set; }

        //[Range(6000,25000,ErrorMessage ="Salary mustbe range 6000 to 25000")]
        [Remote("CheckSalary","Employee"
            ,AdditionalFields = "JobTitle"
            , ErrorMessage ="Salary greater than 6000 L.E")]
        public int Salary { get; set; }

        public string JobTitle { get; set; }

        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must Be jpg or png")]
        public string ImageURL { get; set; }


        public string? Address { get; set; }
       
        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DepartmentID { get; set; }

        public Department? Department { get; set; }
    }
}
