﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorExample
{
    /// <summary>
    /// The 'Element' abstract class
    /// </summary>
    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    /// <summary>
    /// The 'ConcreteElement' class
    /// </summary>
    class Employee : Element
    {
        public Employee(string name, double income, int vacationDays)
        {
            Name = name;
            Income = income;
            VacationDays = vacationDays;
        }

        public string Info
        {
            get
            {
                string info = string.Format("{0} {1}'s Income: {2:C}\r\n", GetType().Name, Name, Income);
                info += string.Format("{0} {1}'s Vacation days: {2}\r\n\r\n", GetType().Name, Name, VacationDays);
                return info;
            }
        }

        public string Name { get; set; }
        public double Income { get; set; }
        public int VacationDays { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// The 'ObjectStructure' class
    /// </summary>
    class Employees
    {
        private List<Employee> employees = new List<Employee>();

        public string Info
        {
            get
            {
                string info = string.Empty;
                foreach (var employee in employees)
                {
                    info += employee.Info;
                }
                if (string.IsNullOrEmpty(info))
                    info = "NO EMPLOYEES";

                return info;
            }
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public void Clear()
        {
            employees.Clear();
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Employee e in employees)
            {
                e.Accept(visitor);
            }
        }
    }

    // Three employee types
    class Clerk : Employee
    {
        public Clerk(string name) : base(name, 25000.0, 14)
        {
        }
    }

    class Director : Employee
    {
        public Director(string name) : base(name, 35000.0, 16)
        {
        }
    }

    class President : Employee
    {
        public President(string name) : base(name, 45000.0, 21)
        {
        }
    }
}
