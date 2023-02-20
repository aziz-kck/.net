using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static AM.Core.Services.FlightService;

namespace AM.Core.Services
{
    public class FlightService : IFlightService
    {
        public IList<Flight> Flights { get; set; }

        public delegate int getScore(Passenger passenger);
        //TP.Q4
        public IList<DateTime> GetFlightDates(string destination)
        {
            //List<DateTime> dates = new List<DateTime>();
            //foreach(var flight in Flights)
            //{
            //    if (flight.Destination == destination)
            //    {
            //        dates.Add(flight.FlightDate);

            //    }

            //}
            // return dates;


            //TP2.Q6 Création de la méthode avec linq

            // return (from flight in Flights
            //where flight.Destination == destination
            //select flight.FlightDate).ToList(); //Select retourne enumérable donc on doit la convertir à ILIST .ToList()
            return Flights.Where(flight => flight.Destination == destination).Select(flight => flight.FlightDate).ToList(); // Une Deuxiéme méthode linq avancée


        }
        // TP.Q5
        public List<Flight> GetFlights(string filtertype, string filtervalue)
        {


            switch (filtertype)
            {
                case "Destination":
                    return Flights.Where(flight => flight.Destination == filtervalue).ToList();
                case "Departure":
                    return Flights.Where(flight => flight.Departure == filtervalue).ToList();
                case "EffectiveArrival":
                    return Flights.Where(flight => flight.EffectiveArrival.ToString() == filtervalue).ToList();
                case "EstimatedDuration":
                    return Flights.Where(flight => flight.EstimatedDuration.ToString() == filtervalue).ToList();
                case "FlightDate":
                    return Flights.Where(flight => flight.FlightDate.ToString() == filtervalue).ToList();
                case "FlightId":
                    return Flights.Where(flight => flight.FlightId.ToString() == filtervalue).ToList();
                default: return new List<Flight>();
            }
        }

        // TP.Q7
        public List<Object> GetShowFlightDetails(int planeId, List<Flight> Flights)
        {
            return Flights.Where(flight => flight.FlightId == planeId)
                         .Select(flight => new { flight.Destination, flight.FlightDate })
                         .ToList<Object>();
        }
        //TP.Q8
        public int GetWeeklyFlightNumber(DateTime StartDate, List<Flight> Flights)
        {
            DateTime EndDate = StartDate.AddDays(7);
            int WeeklyFlightNumber = Flights.Count(flight => flight.FlightDate > StartDate && flight.FlightDate < StartDate);
            return WeeklyFlightNumber;
        }
        //TP.Q9
        public int GetDurationAverage(String Destination, List<Flight> Flights)
        {
            int DurationAverage = Convert.ToInt32(Flights.Where(flight => flight.Destination == Destination).Average(flight => flight.EstimatedDuration));
            return DurationAverage;
        }

        //TP.Q10
        public List<Flight> SortFlights(int IdPlane)
        {
            return Flights.Where(Flights => Flights.FlightId == IdPlane).OrderByDescending(Flights => Flights.EstimatedDuration).ToList();
        }
        public List<int> GetThreeOlderTravellers(int IdPlane, int age, List<Flight> Flights)

        {
            List<int> oldestPassengers = Flights.Where(f => f.FlightId == IdPlane)
                                          .SelectMany(f => f.Passengers)
                                          .OrderByDescending(p => p.Age)
                                          .Take(3)
                                          .Select(p => p.Age)
                                          .ToList();
            return oldestPassengers;
        }

        public List<Object> ShowGroupedFlights(int IdPlane, List<Flight> Flights)
        {
            return Flights.Where(Flights => Flights.FlightId == IdPlane).GroupBy(f => f.Destination)
                .Select(group => new { Destination = group.Key, Flights = group.ToList() }).Cast<Object>().ToList();
        }

        //Question 13.b
        public Passenger GetSeniorPassenger (List<Passenger> passengers, Func<Passenger, int> getScore)
        {
            return passengers.Where(passenger => passenger.Age >= 60)
                             .OrderByDescending(getScore)
                             .FirstOrDefault();
        }
    }

    }
