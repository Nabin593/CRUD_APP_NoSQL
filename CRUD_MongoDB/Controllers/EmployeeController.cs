using CRUD_MongoDB.Models;
using CRUD_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_MongoDB.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeeController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        // GET: EmployeeController
        public async Task<IActionResult> Index()
        {
            var emp = await _EmployeeService.GetAllAsync();

            return View(emp);
        }

        // GET: StudentController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _EmployeeService.GetById(id);

            return View(emp);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                _EmployeeService.CreateAsync(employee);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                var emp = _EmployeeService.GetById(id);

                Employee data = emp.Result;

                return View(data);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _EmployeeService.Update(id, employee);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                var emp = _EmployeeService.GetById(id);

                if (emp == null)
                {
                    return NotFound();
                }

                Employee data = emp.Result;

                return View(data);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee employee)
        {
            try
            {

                _EmployeeService.DeleteAsync(employee.Id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
