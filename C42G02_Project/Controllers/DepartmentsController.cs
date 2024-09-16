using C42G02_project.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace C42G02_Project.Controllers
{
    
    public class DepartmentsController : Controller
    {
        DepartmentRepository DepartmnetRepository;

        public DepartmentsController(DepartmentRepository departmnetRepository)
        {
            DepartmnetRepository = departmnetRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
