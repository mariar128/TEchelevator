using System.Collections.Generic;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public interface IStateDao
    {
        State GetState(string stateAbbreviation);

        State GetStateByCapital(int cityId);

        IList<State> GetStates();
    }
}
