using CampgroundReservations.Models;
using System;
using System.Collections.Generic;

namespace CampgroundReservations.DAO
{
    interface ISiteDao
    {
        IList<Site> GetSitesThatAllowRVs(int parkId);
        IList<Site> GetAvailableSites(int parkId);
        IList<Site> GetAvailableSites(int parkId, DateTime startDate, DateTime endDate);
    }
}
