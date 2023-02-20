using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Plane
    {
        public int Capacity { get; set; }
        public DateTime ManufacturedDate { get; set; }

        public int PlaneId { get; set; }

        public PlaneType MyPlaneType { get; set; }

        public IList<Flight> Flights { get; set; }



        // Question 8 

        public Plane(PlaneType planeType , int capacity , DateTime manufacturedDate  )
        {
            MyPlaneType = planeType;
            Capacity = capacity;
            ManufacturedDate = manufacturedDate;


        }

       

        public Plane()
        {
        }

        public override string ToString()
        {
            return "Capacity : " + Capacity + ";ManufacturedDate : " + ManufacturedDate + ";Plane ID : " + PlaneId
                + ";Plane Type : " + MyPlaneType; 
        }




    }

    public enum PlaneType
    {
        Boing = 1,
        Airbus = 2

    }






}
