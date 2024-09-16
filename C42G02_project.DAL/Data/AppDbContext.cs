using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C42G02_project.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace C42G02_project.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = .; Database= C42G02MVC ; Trusted_Connection = True ; MultipleActiveResultSets = True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration (new DepartmentConfigurations ());
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

        }

        public DbSet<Department> Departments { get; set; }
    }
}
