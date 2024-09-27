
namespace C42G02_project.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }
        public IEnumerable<Employee> GetAll(string Address) => _DbSet.Where(e => e.Address.ToLower() == Address.ToLower()).ToList();



        public IEnumerable<Employee> GetAllWithDepartment() => _DbSet.Include(e => e.Department).ToList();
         
        
    }
}
