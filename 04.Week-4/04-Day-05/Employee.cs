using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Casestudy
{
    internal class Employee
    {
        private string _fullName;
        private decimal _salary;
        private int _age;

        public string EmployeeId { get; }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Full name cannot be empty");
                }

                _fullName = value.Trim();
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 18 || value > 80)
                {
                    throw new ArgumentException("Age must be between 18 and 80");
                }

                _age = value;
            }
        }

        public decimal Salary
        {
            get { return _salary; }

            private set
            {
                if (value < 1000)
                {
                    throw new ArgumentException("Salary should be greater than 1000");
                }

                _salary = value;
            }
        }

        public Employee(string fullName, decimal salary, int age, string employeeId = null)
        {
            if (employeeId == null)
            {
                EmployeeId = GenerateEmployeeId();
            }
            else
            {
                EmployeeId = employeeId;
            }

            FullName = fullName;
            Age = age;
            Salary = salary;
        }

        private string GenerateEmployeeId()
        {
            return "E" + new Random().Next(1000, 9999);
        }

        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0 || percentage > 30)
            {
                throw new ArgumentException("Raise percentage must be between 1 and 30");
            }

            decimal newSalary = Salary + (Salary * percentage / 100);
            Salary = newSalary;

            Console.WriteLine("Raise applied. New Salary: " + Salary);
        }

        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Penalty amount must be greater than 0");
            }

            if (Salary - amount < 1000)
            {
                return false;
            }

            Salary = Salary - amount;
            return true;
        }
    }
}