using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator
{
    public class ReportDataFetcher
    {
        private readonly EmployeeDB _employeeDb;

        public ReportDataFetcher(EmployeeDB employeeDb)
        {
            if (employeeDb == null) throw new ArgumentNullException("employeeDb");
            _employeeDb = employeeDb;
        }

        public List<Employee> FetchData()
        {
            var employees = new List<Employee>();
            Employee employee;
            _employeeDb.Reset();

            // Get all employees
            while ((employee = _employeeDb.GetNextEmployee()) != null)
            {
                employees.Add(employee);
            }

            return employees;
        }
    }



}
