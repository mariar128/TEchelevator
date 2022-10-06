using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservations.Controllers
{
    [Route("reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private static IReservationDao reservationDao;
        private static IHotelDao hotelDao;
        public ReservationsController()
        {
            if (hotelDao == null)
            {
                hotelDao = new HotelMemoryDao();
            }
            if (reservationDao == null)
            {
                reservationDao = new ReservationMemoryDao();
            }
        }

        [HttpGet()]
        public List<Reservation> ListReservations()
        {
            return reservationDao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = reservationDao.Get(id);

            if (reservation != null)
            {
                return reservation;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/hotels/{hotelId}/reservations")]
        public ActionResult<List<Reservation>> ListReservationsByHotel(int hotelId)
        {
            Hotel hotel = hotelDao.Get(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }
            return reservationDao.FindByHotel(hotelId);
        }

        [HttpPost()]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            Reservation added = reservationDao.Create(reservation);
            return Created($"/reservations/{added.Id}", added);
        }
    }
}
