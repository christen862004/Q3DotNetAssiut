using Microsoft.EntityFrameworkCore;

namespace Q3DotNetAssiut.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        //
        public ITIContext():base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=.;Initial Catalog=Assiut_DotNet_Q3;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
