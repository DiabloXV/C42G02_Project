
namespace C42G02_project.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }
        public IEnumerable<Employee> GetAll(string Address)
        {
            return _DbSet.Where(e => e.Address.ToLower() == Address.ToLower()).ToList();
        }
    }
}
