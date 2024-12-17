using RepoPatternDemo.IRepo;
using RepoPatternDemo.Models;

namespace RepoPatternDemo.EmpRepository
{
    public class EmpRepo1 : IEmpRepo
    {
        static List<Employee> employees = null;
        public EmpRepo1()
        {
            if (employees == null)
            {
                employees = new List<Employee>()
                   {
                        new Employee (){Id=1, Name="a", Dept="accts", Exp=9}
                   };
            }
        }

        public List<Employee> GetEmployees()
        {
            return employees.ToList();
        }

        

        public bool AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return true;
        }

       
        

        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }

        public bool EditEmployee(int id, Employee employee)
        {
            Employee temp = GetEmployee(id);
            temp.Dept = employee.Dept;
            return true;
        }

        public bool DeleteEmployee(int id)
        {

            Employee temp = GetEmployee(id);
            employees.Remove(temp);
            return true;
        }
    }
}
