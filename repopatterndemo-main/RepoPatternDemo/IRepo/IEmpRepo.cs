using RepoPatternDemo.Models;

namespace RepoPatternDemo.IRepo
{
    public interface IEmpRepo
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployee(int id);
        public bool AddEmployee(Employee employee);
        public bool EditEmployee(int id, Employee employee);
        public bool DeleteEmployee(int id); 
    }
}
