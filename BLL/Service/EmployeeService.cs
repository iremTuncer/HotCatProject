using BLL.IService;
using BLL.Repository;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeService;

        public EmployeeService(IRepository<Employee> employeeService)
        {
            _employeeService = employeeService;
        }
        public void AddEmployee(Employee employee)
        {
            _employeeService.Insert(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeService.Delete(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeService.GetAll().ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeService.Get(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeService.Update(employee);
        }
    }
}
