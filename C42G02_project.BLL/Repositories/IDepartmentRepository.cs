using C42G02_project.DAL.Models;

namespace C42G02_project.BLL.Repositories
{
    public interface IDepartmentRepository
    {
        int Create(Department entity);
        int Delete(Department entity);
        Department? Get(int id);
        IEnumerable<Department> GetAll();
        int Update(Department entity);
    }
}