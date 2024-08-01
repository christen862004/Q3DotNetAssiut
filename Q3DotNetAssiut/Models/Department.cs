namespace Q3DotNetAssiut.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ManagerName { get; set; }

        public List<Employee>? Emps { get; set; }
    }
}
