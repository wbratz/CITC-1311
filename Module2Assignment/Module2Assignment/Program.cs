using System;
using System.Collections.Generic;

namespace Module2Assignment
{
    class Program
    {
        private static readonly List<string> _airline = new List<string> { "American", "Delta", "Spirit", "United", "Spirit", "Delta", "United", "Southwest", "Southwest" };
        private static readonly List<int> _flightNums = new List<int> { 800, 565, 892, 1844, 1544, 2844, 542, 899, 1313 };
        private static readonly List<string> _fromCity = new List<string> { "Nashville", "Atlantic City", "Los Angeles", "Nashville", "Chicago", "Atlanta", "Chicago", "Las Vegas", "Boston" };
        private static readonly List<int> _gate = new List<int> { 3, 4, 1, 4, 12, 2, 1, 3, 6 };

        static void Main(string[] args)
        {
            var allFlights = FlightFinder(_airline.ToArray(), _flightNums.ToArray(), _fromCity.ToArray(), _gate.ToArray());
            Console.WriteLine("All Flights");
            Console.WriteLine(allFlights);

            Console.WriteLine("Enter an Airline");
            var airline = Console.ReadLine();
            var flightsByAirline = FlightFinder(_airline.ToArray(), _flightNums.ToArray(), _fromCity.ToArray(), _gate.ToArray(), airline);
            var printString = flightsByAirline.Equals(string.Empty) ? "No Results Found\n" : flightsByAirline;
            Console.WriteLine(printString);

            Console.WriteLine("Enter a flight number");
            var flightNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter an Airline");
            airline = Console.ReadLine();
            var flightsByFlightNo = FlightFinder(_airline.ToArray(), _flightNums.ToArray(), _fromCity.ToArray(), _gate.ToArray(), airline, flightNo);
            printString = flightsByFlightNo.Equals(string.Empty) ? "No Results Found\n" : flightsByFlightNo;
            Console.WriteLine(printString);

            Console.WriteLine("Enter a Gate number");
            var gate = int.Parse(Console.ReadLine());
            var flightsByGate = FlightFinder(_airline.ToArray(), _flightNums.ToArray(), _fromCity.ToArray(), _gate.ToArray(), gate);
            printString = flightsByGate.Equals(string.Empty) ? "No Results Found\n" : flightsByGate;
            Console.WriteLine(printString);
        }

        private static string FlightFinder(string[] airlines, int[] flightNumbers, string[] fromCity, int[] gates)
        {
            var result = "";

            for (int i = 0; i < _airline.Count; i++)
            {
                result += $"Flight: {airlines[i]} {flightNumbers[i]}, From: {fromCity[i]}, Gate: {gates[i]} \n";
            }

            return result;
        }

        private static string FlightFinder(string[] airlines, int[] flightNumbers, string[] fromCity, int[] gates, string airline)
        {
            var result = "";

            for (int i = 0; i < _airline.Count; i++)
            {
                if(airlines[i].Equals(airline))
                {
                    result += $"Flight: {airlines[i]} {flightNumbers[i]}, From: {fromCity[i]}, Gate: {gates[i]} \n";
                }
            }

            return result;
        }

        private static string FlightFinder(string[] airlines, int[] flightNumbers, string[] fromCity, int[] gates, string airline, int flight)
        {
            var result = "";

            for (int i = 0; i < _airline.Count; i++)
            {
                if (airlines[i].Equals(airline) && flightNumbers[i] == flight)
                {
                    result += $"Flight: {airlines[i]} {flightNumbers[i]}, From: {fromCity[i]}, Gate: {gates[i]} \n";
                }
            }

            return result;
        }

        private static string FlightFinder(string[] airlines, int[] flightNumbers, string[] fromCity, int[] gates, int gate)
        {
            var result = "";

            for (int i = 0; i < _airline.Count; i++)
            {
                if (gates[i] == gate)
                {
                    result += $"Flight: {airlines[i]} {flightNumbers[i]}, From: {fromCity[i]}, Gate: {gates[i]} \n";
                }
            }

            return result;
        }
    }
}
