using C42G02_project.DAL.Data;
using C42G02_project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42G02_project.BLL.Repositories
{
    public class DepartmentRepository
    {

        /*
         * Get , GetAll , Create , Update , Delete
         */
        //(Dependency Injection) : Is the Design pattern of applying the concept of the "Dependency Inversion"
        // Types:
        // 1- Method Injection => Method([FromServics] AppDbContext appDbContext)
        // 2- Property Injection :
        // [FromServices]
        // Public AppDbContext appDbContext {get;  set;}

        private readonly AppDbContext _appDbContext;
        // 3- CTOR Injection
        public DepartmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Department? Get(int id) => _appDbContext.Departments.Find(id);

        public IEnumerable <Department> GetAll() => _appDbContext.Departments.ToList(); 

        public int Create(Department entity) 
        {
            _appDbContext.Departments.Add(entity);
            return _appDbContext.SaveChanges();
        }

        public int Update(Department entity)
        {
            _appDbContext.Departments.Update(entity);
            return _appDbContext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _appDbContext.Departments.Remove(entity);
            return _appDbContext.SaveChanges();
        }

    }
}
