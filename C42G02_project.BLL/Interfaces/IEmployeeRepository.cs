namespace C42G02_project.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        public IEnumerable<Employee> GetAll(string name);

        public IEnumerable<Employee> GetAllWithDepartment();
    }
}
