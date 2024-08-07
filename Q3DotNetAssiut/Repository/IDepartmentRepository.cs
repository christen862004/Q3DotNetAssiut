using Q3DotNetAssiut.Models;

namespace Q3DotNetAssiut.Repository
{
    public interface IDepartmentRepository
    {

        public string Id { get; set; }

        public void Add(Department obj);


        public void Update(Department obj);


        public void Delete(int id);

        public List<Department> GetAll();

        public Department GetById(int id);

        public void Save();
        
    }
}
