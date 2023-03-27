

using StorageApp.Entities;
using System;
using System.Collections.Generic;

namespace StorageApp.Repositories
{
    public class EmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>();
        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Save()
        {
            foreach (Employee emp in _employees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
