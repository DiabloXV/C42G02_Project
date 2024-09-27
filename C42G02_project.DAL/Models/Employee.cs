using System.ComponentModel.DataAnnotations;
namespace C42G02_project.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string  Address { get; set; }

        public decimal Salary { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Boolean IsActive { get; set; }

        public Department? Department { get; set; }

        public int? DepartmentId { get; set; }
    }
}
