namespace Q3DotNetAssiut.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>();
            
            students.Add(new Student() { Id = 1, Name = "Ahmed", ImageURL = "m.png" });
            students.Add(new Student() { Id = 2, Name = "Mohamed", ImageURL = "m.png" });
            students.Add(new Student() { Id = 3, Name = "REwida", ImageURL = "2.jpg" });
            students.Add(new Student() { Id = 4, Name = "Alaa", ImageURL = "2.jpg" });
        }

        public List<Student> GetAll()
        {
            return students;
        }
        public Student GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
