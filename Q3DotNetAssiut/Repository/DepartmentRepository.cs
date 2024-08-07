using Q3DotNetAssiut.Models;

namespace Q3DotNetAssiut.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        public string Id { get; set; }

        ITIContext context;
        public DepartmentRepository(ITIContext _Context)
        {
            context = _Context;// new ITIContext();
            Id = Guid.NewGuid().ToString();
        }
        //CRUD
        public void Add(Department obj)
        {
            context.Add(obj);
        }
        public void Update(Department obj)
        { 
            context.Update(obj);

        }

        public void Delete(int id)
        {
            Department dept=GetById(id);
            context.Remove(dept);
        }
        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }
        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
