using System.Collections.Generic;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public interface IParkDao
    {
        Park GetPark(int parkId);

        IList<Park> GetParksByState(string stateAbbreviation);

        Park CreatePark(Park park);

        void UpdatePark(Park park);

        void DeletePark(int parkId);

        void AddParkToState(int parkId, string state_abbreviation);

        void RemoveParkFromState(int parkId, string state_abbreviation);
    }
}
