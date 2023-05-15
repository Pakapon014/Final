using System;
using System.Collections.Generic;

class City
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int InfectionLevel { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<City> cities = new List<City>();

        Console.Write("Enter the number of cities in the model: ");
        int numCities = int.Parse(Console.ReadLine());

        for (int i = 0; i < numCities; i++)
        {
            Console.WriteLine("City {0}:", i);
            string cityName = GetCityName(cities);
            int connectedCityID = GetConnectedCityID(cities, i);
            int infectionLevel = 0;

            City city = new City()
            {
                ID = i,
                Name = cityName,
                InfectionLevel = infectionLevel
            };

            cities.Add(city);
        }

        Console.WriteLine("City model information:");
        foreach (City city in cities)
        {
            Console.WriteLine("City ID: {0}, City Name: {1}, Infection Level: {2}", city.ID, city.Name, city.InfectionLevel);
        }
    }

    static string GetCityName(List<City> cities)
    {
        string cityName = "";
        bool validName = false;

        while (!validName)
        {
            Console.Write("Enter city name: ");
            cityName = Console.ReadLine();

            validName = true;
            foreach (City city in cities)
            {
                if (city.Name == cityName)
                {
                    Console.WriteLine("Invalid city name. Please enter a different name.");
                    validName = false;
                    break;
                }
            }
        }

        return cityName;
    }

    static int GetConnectedCityID(List<City> cities, int currentCityID)
    {
        int connectedCityID = -1;
        bool validID = false;

        while (!validID)
        {
            Console.Write("Enter the ID of the city connected to this city (or 0 if none): ");
            connectedCityID = int.Parse(Console.ReadLine());

            if (connectedCityID < 0 || connectedCityID > currentCityID || connectedCityID == currentCityID)
            {
                Console.WriteLine("Invalid ID. Please enter a different ID.");
            }
            else
            {
                validID = true;
            }
        }

        return connectedCityID;
    }
}
