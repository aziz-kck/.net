using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string TelNumber { get; set; }

        public string PassportNumber { get; set; }

        public IList<Flight> Flights { get; set; }

        //TP1.Q14
        int age;
        public int Age {
            get {
                age = (DateTime.Now.Year - BirthDate.Year);
                if( BirthDate.AddYears(age) < DateTime.Now)
                {
                   age--;
                }
                return age;
            }
        }


        public override string ToString()
        {
            return "Birth Date : " + BirthDate + ";FirstName : " + FirstName + ";Last Name : " + LastName +
                ";Email Address :" + EmailAddress + ";Tel Number :" + TelNumber + ";Passport Number :" + PassportNumber
                ;
        }
        // TP1.Question 11.a 
        // 
        // public bool CheckProfile(string firstname, string lastname)
        //{
        //    //if (this.FirstName== firstname && this.LastName == lastname) {
        //    //    return true;
        //    //}
        //    //return false;
        //    return FirstName == firstname && LastName == lastname;
        //}
        // TP1.Question 11.b 
        //public bool CheckProfile(string firstname, string lastname,string email)
        //{
        //    return FirstName == firstname && LastName == lastname && EmailAddress == email;
        //}

        // TP1.Question 11.c 
        public bool CheckProfile(string firstname, string lastname, string email=null)
        {
            

            return FirstName == firstname && LastName == lastname 
                && ( EmailAddress == email || email == null) ;

        }

         public  virtual string GetPassengerType()
        {
            return "I am Passenger ";
        }


        public void GetAge(DateTime birthDate, ref int  calculatedAge)
        {
           
           calculatedAge  =  (DateTime.Now.Year - birthDate.Year);
            if (birthDate.AddYears(calculatedAge) < DateTime.Now)
            {
                calculatedAge--;
            }
         
        }

    }
}
