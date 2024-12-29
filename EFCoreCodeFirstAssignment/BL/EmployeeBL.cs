using DAL;
using DTO;

namespace BL
{
    public class EmployeeBL
    {
        private readonly EmployeeDAL _employeeDL;

        public EmployeeBL(EmployeeDAL employeeDAL)
        {
            _employeeDL = employeeDAL;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeDL.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {

            return _employeeDL.GetEmployee(id);

        }

        public int CreateEmployee(Employee employee)
        {
            return _employeeDL.CreateEmployee(employee);
        }

        public int UpdateEmployee(Employee employee)
        {
            return _employeeDL.UpdateEmployee(employee);
        }

        public int DeleteEmployee(int id)
        {
            return _employeeDL.DeleteEmployee(id);
        }

    }
}