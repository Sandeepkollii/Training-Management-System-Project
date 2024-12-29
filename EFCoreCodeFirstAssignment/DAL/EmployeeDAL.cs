using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDAL
    {
        private readonly EmployeeDbContext _dbContext;

        //EmployeeDbContext _dbContext = new EmployeeDbContext();

        public EmployeeDAL(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return _dbContext.Employees;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee GetEmployee(int id)
        {

            try
            {
                return _dbContext.Employees.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int CreateEmployee(Employee employee)
        {
            int count = 0;
            try
            {
                _dbContext.Employees.Add(employee);
                count = _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return count;
        }

        public int UpdateEmployee(Employee employee)
        {
            int count = 0;
            try
            {
                _dbContext.Employees.Update(employee);
                count = _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return count;
        }

        public int DeleteEmployee(int id)
        {
            int count = 0;
            try
            {
                _dbContext.Employees.Remove(_dbContext.Employees.FirstOrDefault(e => e.Id == id));
                count = _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return count;
        }

    }
}
