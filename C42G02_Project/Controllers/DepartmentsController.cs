using C42G02_project.BLL.Repositories;
using C42G02_project.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace C42G02_Project.Controllers
{
    
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentsController(IDepartmentRepository departmnetRepository)
        {
            _repository = departmnetRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _repository.GetAll();
            return View(departments);
        }

        public IActionResult Create() /*This Action's role is not to create a department instead it
                                       * directs me to a view that is resposible for creating that department by taking  its required date from the user*/
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department) //This action is real deal that implements the inner workings of Creating a department
        {
            //Server side validation
            if(!ModelState.IsValid)
                return View(department);
            _repository.Create(department);
            //return View(nameof(Index)); /* --> this will cause an error since the department you create from the view
                                            //"Create" will actully be passed as null since its not returned by index it self*/
            return RedirectToAction(nameof(Index));                                 
        }

        public IActionResult Details(int? id) 
        {
            /*Retrieve Department and send it to the view*/
            if (!id.HasValue)
                return BadRequest();
            var departmet = _repository.Get(id.Value);
            if (departmet is null)
                return NotFound();
            return View(departmet);
        }

    }
}
