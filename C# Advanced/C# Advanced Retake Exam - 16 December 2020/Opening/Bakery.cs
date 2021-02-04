using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;


        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
                //Capacity--;
            }
        }
        public bool Remove(string name)
        {
            Employee employeeToRemove = data.FirstOrDefault(x => x.Name == name);

            if (employeeToRemove != null)
            {
                data.Remove(employeeToRemove);

                return true;
            }
            return false;
        }


        public Employee GetOldestEmployee()
        {
            var oldest = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldest;
        }
        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);

            return employee;
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (var person in data)
            {
                result.AppendLine(person.ToString());
            }

            return result.ToString();
        }
    }
}
