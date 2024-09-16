using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42G02_project.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field Is Required!")]
        public string Code { get; set; } //Since this is .NET 5 any null reference data type property when mapped to Db it will allow null
        [Required(ErrorMessage = "This Field Is Required!")]
        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
