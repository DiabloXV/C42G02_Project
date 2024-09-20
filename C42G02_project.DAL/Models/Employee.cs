using System.ComponentModel.DataAnnotations;
namespace C42G02_project.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50 , MinimumLength =3)]
        public string Name { get; set; }
        [Range(19,60)]
        public int Age { get; set; }

        public string  Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }

        public Boolean IsActive { get; set; }
    }
}
