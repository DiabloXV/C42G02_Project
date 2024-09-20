using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42G02_project.BLL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class //Constraint to define that TEntity is a class (otherwise it could be anything else)
    {
        //We Create a generic repository that combines both methods of Employee and department since both have the same implementation
        private AppDbContext _DbContext;
        protected DbSet<TEntity> _DbSet;
        /*
         * Get , GetAll , Create , Update , Delete
         */
        //(Dependency Injection) : Is the Design pattern of applying the concept of the "Dependency Inversion"
        // Types:
        // 1- Method Injection => Method([FromServics] AppDbContext appDbContext)
        // 2- Property Injection :
        // [FromServices]
        // Public AppDbContext appDbContext {get;  set;}
        // 3- CTOR Injection
        public GenericRepository(AppDbContext dbContext)
        {
            _DbContext = dbContext;
            _DbSet = _DbContext.Set<TEntity>();
        }

        public int Create(TEntity entity)
        {
            _DbSet.Add(entity);
            return _DbContext.SaveChanges();

        }

        public int Delete(TEntity entity)
        {
            _DbSet.Remove(entity);
            return _DbContext.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _DbSet.Update(entity);
            return _DbContext.SaveChanges();
        }

        public TEntity? Get(int id) => _DbSet.Find(id);
       

        public IEnumerable<TEntity> GetAll() => _DbSet.ToList(); 
      
    }
}
