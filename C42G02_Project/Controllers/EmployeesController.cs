using C42G02_project.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace C42G02_Project.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _repo;

        public EmployeesController(IEmployeeRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //ViewData => Dictionary <String, Object>
            //Both ViewBag and ViewData has the type of dictionary if key is repeated in Name it will be overriden
            //ViewBag.Message = "Hello2";
            //ViewData["Message"] = "Hello1";

            //C# 4 Featuring ViewBag


            var employees = _repo.GetAll();
            return View(employees);
        }

        public IActionResult Create() /*This Action's role is not to create a department instead it
                                       * directs me to a view that is resposible for creating that department by taking  its required date from the user*/
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee) //This action is real deal that implements the inner workings of Creating a department
        {
            //Server side validation
            if (!ModelState.IsValid)
                return View(employee);
            _repo.Create(employee);
            //return View(nameof(Index)); /* --> this will cause an error since the department you create from the view
            //"Create" will actully be passed as null since its not returned by index it self*/
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) => EmployeeControllerHandler(id, nameof(Details));


        public IActionResult Edit(int? id) => EmployeeControllerHandler(id, nameof(Edit));


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee employee) //This action is real deal that implements the inner workings of Creating a department
        {
            //Server side validation
            if (id != employee.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    if (_repo.Update(employee) > 0)
                        TempData["Message"] = "Employee Updated Successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //Log Exception
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(employee);
        }

        public IActionResult Delete(int? id) => EmployeeControllerHandler(id, nameof(Delete));


        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var employee = _repo.Get(id.Value);
            if (employee is null)
                return NotFound();

            try
            {
                _repo.Delete(employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(employee);
        }

        private IActionResult EmployeeControllerHandler(int? id, string ViewName)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = _repo.Get(id.Value);
            if (employee is null)
                return NotFound();
            return View(ViewName, employee);
        }
    }
}
