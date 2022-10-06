using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservations.Controllers
{
    [Route("reservations")]
    [ApiController]
    [Authorize]
    public class ReservationsController : ControllerBase
    {
        private IReservationDao reservationDao;
        private IHotelDao hotelDao;
        public ReservationsController(IHotelDao hotelDao, IReservationDao reservationDao)
        {
            this.hotelDao = hotelDao;
            this.reservationDao = reservationDao;
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

        [HttpPut("{id}")]
        public ActionResult<Reservation> UpdateReservation(int id, Reservation reservation)
        {
            Reservation existingReservation = reservationDao.Get(id);
            if (existingReservation == null)
            {
                return NotFound();
            }

            Reservation result = reservationDao.Update(id, reservation);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            Reservation existingReservation = reservationDao.Get(id);
            if (existingReservation == null)
            {
                return NotFound();
            }

            bool result = reservationDao.Delete(id);
            if (result)
            {
                return NoContent();
            }
            return StatusCode(500); //in case DAO has an error in deleting
        }
    }
}
