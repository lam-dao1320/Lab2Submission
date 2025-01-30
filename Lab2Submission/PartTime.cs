using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Submission
{
    public class PartTime : Employee
    {
        private double rate;
        private double hours;
        public PartTime(string id, string name, string address, string phone, string sin, string rate, string hours) :
            base(id, name, address, phone, sin)
        {
            this.rate = Convert.ToDouble(rate);
            this.hours = Convert.ToDouble(hours);
        }
        public override double CalculatePay()
        {
            return rate * hours;
        }
    }
}
