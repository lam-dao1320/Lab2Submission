using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Submission
{
    public class Salaried : Employee
    {
        private double salary;
        public Salaried(string id, string name, string address, string phone, string sin, string salary) :
            base(id, name, address, phone, sin)
        {
            this.salary = Convert.ToDouble(salary);
        }
        public override double CalculatePay()
        {
            return salary;
        }
    } 
}
