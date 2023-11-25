using Employee_Leave_Managent.Interfaces;
using Employee_Leave_Managent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Leave_Managent.Data.Migrations;

namespace Employee_Leave_Managent.Repository
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetEmployeeById(string id)
        {
            return _dbContext.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }
    }
}
