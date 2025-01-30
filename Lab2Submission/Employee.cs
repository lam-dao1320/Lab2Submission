using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Submission
{
    public class Employee
    {
        // private data
        private string id;
        private string name;
        private string address;
        private string phone;
        private string sin;

        // properties
        public string Name { get { return name; } }

        // constructor
        public Employee(string id, string name, string address, string phone, string sin)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
        }
        public virtual double CalculatePay()
        {
            return 0;
        }
    }
}
