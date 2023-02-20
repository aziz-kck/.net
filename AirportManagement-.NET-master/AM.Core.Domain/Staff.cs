using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }

        public string Function { get; set; }

        public float Salary { get; set; }


        public override string ToString()
        {
            return base.ToString() + "Employment Date :" + EmploymentDate + ";Fuction :" + Function + ";Salary :" + Salary;
        }


        public override string GetPassengerType()
        {
            return base.GetPassengerType() + " I am a staff  ";
        }

    }
}
