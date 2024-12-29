using BL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCodeFirstAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeBL _employeeBL;

        public EmployeeController(EmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var employees = _employeeBL.GetEmployees();
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = _employeeBL.GetEmployee(id);
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                int result = _employeeBL.CreateEmployee(employee);
                if (result > 0)
                    RedirectToAction(nameof(Index));

                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = _employeeBL.GetEmployee(id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee editedEmployee)
        {
            try
            {
                int result = _employeeBL.UpdateEmployee(editedEmployee);
                if (result > 0)
                    RedirectToAction(nameof(Index));

                return View(editedEmployee);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _employeeBL.GetEmployee(id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = _employeeBL.DeleteEmployee(id);

                if (result > 0)
                    return RedirectToAction(nameof(Index));

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
