using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using USCitiesAndParks.DAO;
using USCitiesAndParks.Models;

namespace USCitiesAndParks
{
    public class USCitiesAndParksCLI
    {
        private readonly ICityDao cityDao;
        private readonly IStateDao stateDao;
        private readonly IParkDao parkDao;

        public USCitiesAndParksCLI(ICityDao cityDao, IStateDao stateDao, IParkDao parkDao)
        {
            this.cityDao = cityDao;
            this.stateDao = stateDao;
            this.parkDao = parkDao;
        }

        public void RunCLI()
        {
            DisplayBanner();
            bool running = true;
            while (running)
            {
                DisplayMenu();
                int selection = PromptForInt("Please select an option: ");
                if (selection == 1)
                {
                    ManageCityInfo();
                }
                else if (selection == 2)
                {
                    AddNewCity();
                }
                else if (selection == 3)
                {
                    ManageParkInfo();
                }
                else if (selection == 4)
                {
                    AddNewPark();
                }
                else if (selection == 5)
                {
                    running = false;
                }
                else
                {
                    DisplayError("Invalid option selected.");
                }
            }
        }

        private void ManageCityInfo()
        {
            City city = PromptForCity();
            Console.WriteLine();
            DisplayCity(city);
            string response = PromptForString("(U)pdate this city, (D)elete this city, or press Enter to continue: ");
            if (response.ToUpper() == "U")
            {
                UpdateCity(city);
            }
            else if (response.ToUpper() == "D")
            {
                DeleteCity(city);
            }
        }

        private void UpdateCity(City cityToUpdate)
        {
            string newName = PromptForString("New name (enter to leave unchanged): ");
            if (!string.IsNullOrWhiteSpace(newName))
            {
                cityToUpdate.CityName = newName;
            }
            int newPopulation = PromptForInt("New population (enter to leave unchanged): ");
            if (newPopulation >= 0)
            {
                cityToUpdate.Population = newPopulation;
            }
            decimal newArea = PromptForDecimal("New area (enter to leave unchanged): ");
            if (newArea >= 0)
            {
                cityToUpdate.Area = newArea;
            }

            cityDao.UpdateCity(cityToUpdate);
            Console.WriteLine($"\nUpdated {cityToUpdate}\n");
        }

        private void DeleteCity(City cityToDelete)
        {
            State state = stateDao.GetStateByCapital(cityToDelete.CityId);
            if (state != null)
            {
                DisplayError($"Cannot delete capital of {state.StateName}");
            }
            else
            {
                cityDao.DeleteCity(cityToDelete.CityId);
                Console.WriteLine($"\nDeleted {cityToDelete}\n\n");
            }
        }

        private void AddNewCity()
        {
            City newCity = PromptForNewCityData();
            newCity = cityDao.CreateCity(newCity);
            Console.WriteLine("\nAdded the following city to the database:");
            DisplayCity(newCity);
        }

        private void ManageParkInfo()
        {
            Park park = PromptForPark();
            Console.WriteLine();
            DisplayPark(park);
            string response = PromptForString("(U)pdate this park, (D)elete this park, or press Enter to continue: ");
            if (response.ToUpper() == "U")
            {
                UpdatePark(park);
            }
            else if (response.ToUpper() == "D")
            {
                DeletePark(park);
            }
        }

        private void UpdatePark(Park parkToUpdate)
        {
            string newName = PromptForString("New name (enter to leave unchanged): ");
            if (!string.IsNullOrWhiteSpace(newName))
            {
                parkToUpdate.ParkName = newName;
            }
            DateTime newDateEstablished = PromptForDate("New date established (YYYY-MM-DD or enter to leave unchanged): ");
            if (newDateEstablished != DateTime.MinValue)
            {
                parkToUpdate.DateEstablished = newDateEstablished;
            }
            decimal newArea = PromptForDecimal("New area (enter to leave unchanged): ");
            if (newArea >= 0)
            {
                parkToUpdate.Area = newArea;
            }
            string reply = PromptForString("Does the park offer camping (Y/N or enter to leave unchanged)? ");
            if (reply.ToUpper() == "Y")
            {
                parkToUpdate.HasCamping = true;
            }
            else if (reply.ToUpper() == "N")
            {
                parkToUpdate.HasCamping = false;
            }

            parkDao.UpdatePark(parkToUpdate);
            Console.WriteLine($"\nUpdated {parkToUpdate}\n");
        }

        private void DeletePark(Park parkToDelete)
        {
            parkDao.DeletePark(parkToDelete.ParkId);
            Console.WriteLine($"\nDeleted {parkToDelete}\n");
        }

        private void AddNewPark()
        {
            Park newPark = PromptForNewParkData();

            newPark = parkDao.CreatePark(newPark);
            Console.WriteLine("\nAdded the following park to the database:");
            DisplayPark(newPark);

            string stateAbbrs = "";
            while (string.IsNullOrWhiteSpace(stateAbbrs))
            {
                stateAbbrs = PromptForString("List of abbreviations for the states this park is located in (separated by commas): ");
            }
            stateAbbrs = stateAbbrs.Trim().ToUpper();
            foreach (string stateAbbr in stateAbbrs.Split(","))
            {
                State state = stateDao.GetState(stateAbbr.Trim());
                if (state != null)
                {
                    parkDao.AddParkToState(newPark.ParkId, state.StateAbbreviation);
                    Console.WriteLine($"Added {newPark.ParkName} to {state.StateName}");
                }
            }
            Console.WriteLine();
        }

        private void DisplayBanner()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|  US Cities and Parks Data Management  |");
            Console.WriteLine("-----------------------------------------");
        }

        private void DisplayMenu()
        {
            Console.WriteLine("1. View or modify city information");
            Console.WriteLine("2. Add new city");
            Console.WriteLine("3. View or modify park information");
            Console.WriteLine("4. Add new park");
            Console.WriteLine("5. Exit");
        }

        private void DisplayError(string message)
        {
            Console.WriteLine();
            Console.WriteLine("***" + message + "***");
            Console.WriteLine();
        }

        private void DisplayCity(City city)
        {
            Console.WriteLine(city);
            Console.WriteLine($"Population: {city.Population} Area: {city.Area} sq. km\n\n");
        }

        private void DisplayPark(Park park)
        {
            Console.WriteLine(park);
            Console.WriteLine($"Established: {park.DateEstablished.ToShortDateString()} Area: {park.Area} sq. km");
            Console.WriteLine("This park {0} camping.\n\n", park.HasCamping ? "offers" : "does not offer");
        }

        private string PromptForString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private int PromptForInt(string prompt)
        {
            return (int)PromptForDecimal(prompt);
        }

        private decimal PromptForDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string response = Console.ReadLine();
                if (decimal.TryParse(response, out decimal parsed))
                {
                    return parsed;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(response))
                    {
                        return -1; //Assumes negative numbers are never valid entries.
                    }
                    else
                    {
                        DisplayError("Numbers only, please.");
                    }
                }
            }
        }

        private DateTime PromptForDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string response = Console.ReadLine();
                try
                {
                    return DateTime.Parse(response);
                }
                catch
                {
                    if (string.IsNullOrWhiteSpace(response))
                    {
                        return DateTime.MinValue;
                    }
                    else
                    {
                        DisplayError("Please format as YYYY-MM-DD.");
                    }
                }
            }
        }

        private State PromptForState()
        {
            while (true)
            {
                Console.Write("Please enter a state abbreviation (enter ? to list state abbreviations): ");
                string response = Console.ReadLine();
                if (response == "?")
                {
                    foreach (State state in stateDao.GetStates())
                    {
                        Console.WriteLine(state.StateAbbreviation + "   " + state.StateName);
                    }
                }
                else
                {
                    State result = stateDao.GetState(response.ToUpper());
                    if (result == null)
                    {
                        DisplayError("Invalid state abbreviation.");
                    }
                    else
                    {
                        return result;
                    }
                }
            }
        }

        private City PromptForCity()
        {
            IList<City> cities = new List<City>();
            while (cities.Count == 0)
            {
                Console.WriteLine("What state is the city in?");
                State state = PromptForState();
                cities = cityDao.GetCitiesByState(state.StateAbbreviation);
                if (cities.Count == 0)
                {
                    DisplayError("No cities in selected state.");
                }
            }
            for (int i = 0; i < cities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cities[i].CityName}");
            }
            Console.WriteLine();
            while (true)
            {
                try
                {
                    int selection = PromptForInt("Please select a city: ");
                    return cities[selection - 1];
                }
                catch {
                    DisplayError("Invalid selection.");
                }
            }
        }

        private City PromptForNewCityData()
        {
            City city = new City();

            string name = "";
            while (string.IsNullOrWhiteSpace(name))
            {
                name = PromptForString("City name: ");
            }
            city.CityName = name;
            int population = -1;
            while (population < 0)
            {
                population = PromptForInt("Population: ");
            }
            city.Population = population;
            decimal area = -1;
            while (area < 0)
            {
                area = PromptForDecimal("Area (in sq. km.): ");
            }
            city.Area = area;

            Console.WriteLine("What state is this city in?");
            State state = PromptForState();
            city.StateAbbreviation = state.StateAbbreviation;

            return city;
        }

        private Park PromptForPark()
        {
            IList<Park> parks = new List<Park>();
            while (parks.Count == 0)
            {
                Console.WriteLine("What state is the park in?");
                State state = PromptForState();
                parks = parkDao.GetParksByState(state.StateAbbreviation);
                if (parks.Count == 0)
                {
                    DisplayError("No parks in selected state.");
                }
            }
            for (int i = 0; i < parks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {parks[i].ParkName}");
            }
            Console.WriteLine();
            while (true)
            {
                try
                {
                    int selection = PromptForInt("Please select a park: ");
                    return parks[selection - 1];
                }
                catch {
                    DisplayError("Invalid selection.");
                }
            }
        }

        private Park PromptForNewParkData()
        {
            Park park = new Park();

            string name = "";
            while (string.IsNullOrWhiteSpace(name))
            {
                name = PromptForString("Park name: ");
            }
            park.ParkName = name;
            DateTime dateEstablished = DateTime.MinValue;
            while (dateEstablished == DateTime.MinValue)
            {
                dateEstablished = PromptForDate("Date established (YYYY-MM-DD): ");
            }
            park.DateEstablished = dateEstablished;
            decimal area = -1;
            while (area < 0)
            {
                area = PromptForDecimal("Area (in sq. km.): ");
            }
            park.Area = area;
            string reply = PromptForString("Does this park offer camping (Y/N)? ");
            park.HasCamping = reply.ToUpper() == "Y";

            return park;
        }
    }
}
