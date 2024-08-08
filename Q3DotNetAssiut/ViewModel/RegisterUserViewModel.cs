using System.ComponentModel.DataAnnotations;

namespace Q3DotNetAssiut.ViewModel
{
    public class RegisterUserViewModel
    {
        
        public string UserName { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Compare("Password")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
        public string Address { get; set; }
    }
}
