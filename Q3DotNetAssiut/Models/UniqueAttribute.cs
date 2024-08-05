using System.ComponentModel.DataAnnotations;

namespace Q3DotNetAssiut.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        public int xyz { get; set; }
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string nameFromREquest = value.ToString();


            Employee EmployeeFromRequest=
                (Employee) validationContext.ObjectInstance;

            
            ITIContext context = new ITIContext();
            Employee EmployeeFromDB
                = context.Employee
                .FirstOrDefault(e =>
                e.Name == nameFromREquest && e.DepartmentID==EmployeeFromRequest.DepartmentID);
            if (EmployeeFromDB == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("NAme Already Exist!!! :(");
        }
    }
}
