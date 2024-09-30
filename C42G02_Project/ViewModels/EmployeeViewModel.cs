namespace C42G02_Project.ViewModels
{
    //View Model (WILL NOT INCLUDE) any Database Configurations since it Deals only with the views
    //Any Data Configurations SHOULD ONLY exist in the DAL Model 
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Name { get; set; }
        [Range(19, 60)]
        public int Age { get; set; }

        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }

        public Boolean IsActive { get; set; }

        public Department? Department { get; set; }

        public int? DepartmentId { get; set; }
    }
}
