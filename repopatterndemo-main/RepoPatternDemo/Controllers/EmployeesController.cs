using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatternDemo.IRepo;
using RepoPatternDemo.Models;

namespace RepoPatternDemo.Controllers
{


    //class Car
    //{
    //    Wheel _wheel;
    //    public Car(Wheel wheel)
    //    {
    //        _wheel = wheel;
    //    }
    //}
    public class EmployeesController : Controller
    {
        //// DI
        //private EmpRepository.EmpRepo1 _repo;

        //public EmployeesController(EmpRepository.EmpRepo1 repo)
        //{
        //    _repo = repo;
        //}

        // DI
        //private EmpRepository.EmpRepo2 _repo;

        //public EmployeesController(EmpRepository.EmpRepo2 repo)
        //{
        //    _repo = repo;
        //}

        private IEmpRepo _repo;

        public EmployeesController(IEmpRepo  repo)
        {
            _repo = repo;
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            return View(_repo.GetEmployees());
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
             return View(_repo.GetEmployee(id));
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                _repo.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = _repo.GetEmployee(id);

            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                _repo.EditEmployee(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            { 
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = _repo.GetEmployee(id);
            

            return View(employee);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _repo.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
