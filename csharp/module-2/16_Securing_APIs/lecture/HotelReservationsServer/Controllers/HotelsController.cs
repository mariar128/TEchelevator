using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.DAO;
using Microsoft.AspNetCore.Authorization;

namespace HotelReservations.Controllers
{
    [Route("hotels")]
    [ApiController]
    [Authorize] // lock down the whole controller and require a token
    public class HotelsController : ControllerBase
    {
        private IHotelDao hotelDao;

        public HotelsController(IHotelDao hotelDao)
        {
            this.hotelDao = hotelDao;
        }

        [AllowAnonymous] // override our decision at the top to allow public access to this endpoint
        [HttpGet()]
        public List<Hotel> ListHotels()
        {
            return hotelDao.List();
        }

        [HttpGet("{id}")]
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

        [HttpGet("filter")]
        public List<Hotel> FilterByStateOrCity(string state, string city)
        {
            List<Hotel> filteredHotels = new List<Hotel>();

            List<Hotel> hotels = ListHotels();
            // return hotels that match state
            foreach (Hotel hotel in hotels)
            {
                if (city != null)
                {
                    // if city was passed we don't care about the state filter
                    if (hotel.Address.City.ToLower().Equals(city.ToLower()))
                    {
                        filteredHotels.Add(hotel);
                    }
                }
                else
                {
                    if (hotel.Address.State.ToLower().Equals(state.ToLower()))
                    {
                        filteredHotels.Add(hotel);
                    }
                }
            }
            return filteredHotels;
        }

    }
}
