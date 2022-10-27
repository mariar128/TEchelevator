using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.DAO;

namespace HotelReservations.Controllers
{
    [Route("hotels")] // route attribute defines the location of the controller ("localhost:????/hotels" or "localhost:5001/hotels")
    //[Route([controller])] would result in the same thing here since this is the HotelsController
    [ApiController]

    public class HotelsController : ControllerBase //inherit from ControllerBase
    {
        private static IHotelDao hotelDao;

        public HotelsController() // in our constructor we have our DAO for the hotels
        {
            if (hotelDao == null)
            {
                hotelDao = new HotelMemoryDao();
            }
        }

        [HttpGet()] // attriubte says that this method handles GET requests
        public List<Hotel> ListHotels()
        {
            return hotelDao.List();
        }

        [HttpGet("{id}")] // hotels/:id <-- id added onto the route
        public ActionResult<Hotel> GetHotel(int id)
        {
            Hotel hotel = hotelDao.Get(id);

            if (hotel != null)
            {
                return hotel;
            }
            else
            {
                return NotFound();
            }
        }
    }
}
