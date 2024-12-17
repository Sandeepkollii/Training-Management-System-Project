using RepoPatternDemo.Context;
using RepoPatternDemo.IRepo;
using RepoPatternDemo.Models;

namespace RepoPatternDemo.EmpRepository
{
    public class EmpRepo2 : IEmpRepo
    {
        private EmpDbContext _context;
        public EmpRepo2(EmpDbContext context)
        {
            _context = context;

        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee GetEmployee(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public bool AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return true;
        }

        public bool EditEmployee(int id, Employee employee)
        {
            Employee temp = GetEmployee(id);
            temp.Dept = employee.Dept;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            Employee temp = GetEmployee(id);
            _context.Employees.Remove(temp);
            _context.SaveChanges();
            return true;
        }

    }
}
