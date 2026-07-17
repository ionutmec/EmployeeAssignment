using System;

namespace EmployeeComparisonApp
{
    // Defines the Employee class with Id, FirstName, and LastName properties
    public class Employee
    {
        // Unique identifier for the employee
        public int Id { get; set; }

        // Employee's first name
        public string FirstName { get; set; }

        // Employee's last name
        public string LastName { get; set; }

        // Overloading the "==" operator to compare two Employee objects by their Id property
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // If both objects point to the same memory location, they are equal
            if (ReferenceEquals(emp1, emp2))
            {
                return true;
            }

            // If either object is null (but not both), they cannot be equal
            if (emp1 is null || emp2 is null)
            {
                return false;
            }

            // Return true if the IDs match, otherwise return false
            return emp1.Id == emp2.Id;
        }

        // Comparison operators must be overloaded in pairs; overloading the "!=" operator
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            // The "!=" operator returns the exact opposite result of the "==" operator
            return !(emp1 == emp2);
        }

        // Best practice: Override Equals when overloading reference equality operators
        public override bool Equals(object obj)
        {
            // Safely cast the object to an Employee and verify it is not null
            if (obj is Employee otherEmployee)
            {
                // Defer the comparison logic to our overloaded "==" operator
                return this == otherEmployee;
            }
            // Return false if the object is null or not an Employee instance
            return false;
        }

        // Best practice: Override GetHashCode when overriding Equals
        public override int GetHashCode()
        {
            // Return the hash code of the Id property since it defines our equality
            return Id.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the first Employee object with ID 1
            Employee employee1 = new Employee 
            { 
                Id = 1, 
                FirstName = "John", 
                LastName = "Doe" 
            };

            // Instantiate a second Employee object with the same ID (1) but different names
            Employee employee2 = new Employee 
            { 
                Id = 1, 
                FirstName = "Jane", 
                LastName = "Smith" 
            };

            // Instantiate a third Employee object with a completely different ID (2)
            Employee employee3 = new Employee 
            { 
                Id = 2, 
                FirstName = "Alice", 
                LastName = "Johnson" 
            };

            // Print header text to the console interface
            Console.WriteLine("--- Employee Comparison Testing ---");

            // Compare employee1 and employee2 using our overloaded "==" operator
            if (employee1 == employee2)
            {
                // This block executes because both employees share the same Id value (1)
                Console.WriteLine($"Success: {employee1.FirstName} and {employee2.FirstName} are considered EQUAL because their IDs match.");
            }
            else
            {
                Console.WriteLine("Error: Employees are not equal.");
            }

            // Compare employee1 and employee3 using our overloaded "!=" operator
            if (employee1 != employee3)
            {
                // This block executes because employee1 has ID 1 and employee3 has ID 2
                Console.WriteLine($"Success: {employee1.FirstName} and {employee3.FirstName} are considered NOT EQUAL because their IDs are different.");
            }
            else
            {
                Console.WriteLine("Error: Employees are equal.");
            }

            // Keep the console window open until the user presses a key
            Console.ReadLine();
        }
    }
}