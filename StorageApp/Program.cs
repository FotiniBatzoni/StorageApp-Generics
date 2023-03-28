using StorageApp.Data;
using StorageApp.Entities;
using StorageApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            AddEmployees(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganazations(organizationRepository);

            Console.ReadLine();
        }

        private static void WriteAllToConsole(IRepository<Employee> employeeRepository)
        {
            var items = employeeRepository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id:2 : {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Julia" });
            employeeRepository.Add(new Employee { FirstName = "Anna" });
            employeeRepository.Add(new Employee { FirstName = "Tomas" });
            employeeRepository.Save();
        }

        private static void AddOrganazations(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "PluralSight" });
            organizationRepository.Add(new Organization { Name = "Globomatics" });
            organizationRepository.Save();
        }
    }
}
