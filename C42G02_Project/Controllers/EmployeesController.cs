
namespace C42G02_Project.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository repository, IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _employeeRepository = repository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //ViewData => Dictionary <String, Object>
            //Both ViewBag and ViewData has the type of dictionary if key is repeated in Name it will be overriden
            //ViewBag.Message = "Hello2";
            //ViewData["Message"] = "Hello1";

            //C# 4 Featuring ViewBag


            var employees = _employeeRepository.GetAllWithDepartment(); //Retrieve All employees along with their departments

            var employeesViewModel = _mapper.Map<IEnumerable <Employee>, IEnumerable <EmployeeViewModel>>(employees);

            return View(employeesViewModel);
        }

        [IgnoreAntiforgeryToken]
        /*This Action's role is not to create a department instead it
        * directs me to a view that is resposible for creating that department by taking  its required date from the user*/
        public IActionResult Create() 
        {
            var departments = _departmentRepository.GetAll();
            SelectList listItems = new SelectList(departments, "Id" , "Name");
            ViewBag.Departments = listItems;
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM) //This action is real deal that implements the inner workings of Creating a department
        {
            //Server side validation
            var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
            if (!ModelState.IsValid)
                return View(employeeVM);
            _employeeRepository.Create(employee);
            //return View(nameof(Index)); /* --> this will cause an error since the department you create from the view
            //"Create" will actully be passed as null since its not returned by index it self*/
            return RedirectToAction(nameof(Index));
        }
        [IgnoreAntiforgeryToken]
        public IActionResult Details(int? id) => EmployeeControllerHandler(id, nameof(Details));

        [IgnoreAntiforgeryToken]
        public IActionResult Edit(int? id) => EmployeeControllerHandler(id, nameof(Edit));


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVM) //This action is real deal that implements the inner workings of Creating a department
        {
            //Server side validation
            if (id != employeeVM.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    if (_employeeRepository.Update(employee) > 0)
                        TempData["Message"] = "Employee Updated Successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //Log Exception
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(employeeVM);
        }

        public IActionResult Delete(int? id) => EmployeeControllerHandler(id, nameof(Delete));


        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var employee = _employeeRepository.Get(id.Value);
            if (employee is null)
                return NotFound();

            try
            {
                _employeeRepository.Delete(employee);
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
            if(ViewName == nameof(Edit))
            {
                var departments = _departmentRepository.GetAll();
                SelectList listItems = new SelectList(departments, "Id", "Name");
                ViewBag.Departments = listItems;
            }
            if (!id.HasValue)
                return BadRequest();
            var employee = _employeeRepository.Get(id.Value);
            if (employee is null)
                return NotFound();
            var employeeVM = _mapper.Map<EmployeeViewModel>(employee); //This object of the injected package automapper maps the employee of type IGeneric to an employeeVM of type EmployeeViewModel
            return View(ViewName, employeeVM);
        }
    }
}
