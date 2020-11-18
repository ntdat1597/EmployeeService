using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        EmployeeDataDataContext data = new EmployeeDataDataContext();

        public bool createDepartment(Department newDepartment)
        {
            try
            {
                data.Departments.InsertOnSubmit(newDepartment);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool createEmployee(Employee newEmployee)
        {
            try
            {
                data.Employees.InsertOnSubmit(newEmployee);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteDepartment(string id)
        {
            try
            {
                var department = data.Departments.Where(c => c.DepartmentID == int.Parse(id)).FirstOrDefault();
                data.Departments.DeleteOnSubmit(department);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteEmployee(string id)
        {
            try
            {
                var employee = data.Employees.Where(c => c.EmployeeID == int.Parse(id)).FirstOrDefault();
                data.Employees.DeleteOnSubmit(employee);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editDepartment(string id, Department newDepartment)
        {
            try
            {
                var department = data.Departments.Where(c => c.DepartmentID == int.Parse(id)).FirstOrDefault();
                data.Departments.DeleteOnSubmit(department);
                data.Departments.InsertOnSubmit(newDepartment);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editEmployee(string id, Employee newEmployee)
        {
            try
            {
                var employee = data.Employees.Where(c => c.EmployeeID == int.Parse(id)).FirstOrDefault();
                data.Employees.DeleteOnSubmit(employee);
                data.Employees.InsertOnSubmit(newEmployee);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Department> GetDepartments()
        {
            try
            {
                var department = (from Department in data.Departments select Department).ToList();
                return department;
            }
            catch
            {
                return null;
            }
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                var employee = (from Employee in data.Employees select Employee).ToList();
                return employee;
            }
            catch
            {
                return null;
            }
        }
    }
}
