﻿using StorageApp.Data;
using StorageApp.Entities;
using StorageApp.Repositories;
using System;


namespace StorageApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var itemAdded = new ItemAdded<Employee>(EmployeeAdded);
            //or
            //ItemAdded<Employee> itemAdded = EmployeeAdded;
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            employeeRepository.ItemAdded += EmployeeRepository_ItemAdded;
            

            AddEmployees(employeeRepository);

            AddManagers(employeeRepository);

            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganazations(organizationRepository);
            WriteAllToConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void EmployeeRepository_ItemAdded(object sender, Employee e)
        {
            Console.WriteLine($"Employee added => {e.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {

            var saraManager = new Manager { FirstName = "Sara" };
            var saraManagerCopy = saraManager.Copy();
            managerRepository.Add(saraManager);

            if (saraManagerCopy != null)
            {
                saraManagerCopy.FirstName += "_Copy";
                managerRepository.Add(saraManagerCopy);
            }

            managerRepository.Add(new Manager { FirstName = "Henry" });
            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
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
            var employees = new[]
            {
                new Employee { FirstName = "Julia" },
                new Employee { FirstName = "Anna" },
                new Employee { FirstName = "Tomas" }
            };
            employeeRepository.AddBatch( employees);
        }

        private static void AddOrganazations(IRepository<Organization> organizationRepository)
        {
            var organazations = new[]
            {
                new Organization { Name = "PluralSight" },
                new Organization { Name = "Globomatics" }
            };
            organizationRepository.AddBatch(organazations);

        }

    }
}
