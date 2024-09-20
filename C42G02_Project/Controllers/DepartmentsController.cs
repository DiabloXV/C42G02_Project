using System.CodeDom;

namespace C42G02_Project.Controllers
{

    public class DepartmentsController : Controller
    {
        //private  IGenericRepository <Department> _repository;'
        private IDepartmentRepository _repository;

        public DepartmentsController(IDepartmentRepository repository)
        {
            _repository = repository;
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

        public IActionResult Details(int? id) => DepartmentControllerHandler(id, nameof(Details));


        public IActionResult Edit(int? id) => DepartmentControllerHandler(id, nameof(Edit));


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id,Department department) //This action is real deal that implements the inner workings of Creating a department
        {
            //Server side validation
            if (id != department.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex) 
                {
                    //Log Exception
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(department);
        }

        public IActionResult Delete(int? id) => DepartmentControllerHandler(id, nameof(Delete));


        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var departmet = _repository.Get(id.Value);
            if (departmet is null)
                return NotFound();

            try
            {
                _repository.Delete(departmet);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(departmet);
        }
        
        private IActionResult DepartmentControllerHandler(int? id, string ViewName)
        {
            if (!id.HasValue)
                return BadRequest();
            var departmet = _repository.Get(id.Value);
            if (departmet is null)
                return NotFound();
            return View(ViewName, departmet);
        }
    }
}
