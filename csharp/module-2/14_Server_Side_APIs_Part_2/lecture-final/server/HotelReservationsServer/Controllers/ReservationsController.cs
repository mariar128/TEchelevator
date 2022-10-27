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


        //update reservation
        [HttpPut("{id}")] // /reservations/:id 
        public ActionResult<Reservation> UpdateReservation(int id, Reservation reservation)
        {
            Reservation existingReservation = reservationDao.Get(id);
            if (existingReservation == null) //if the reservation doesn't exist 
            {
                return NotFound(); //404
            }

            //do what you gotta do to update the thing
            Reservation updatedReservation = reservationDao.Update(existingReservation.Id, reservation);

            return updatedReservation;
        }

        //delete reservation
        [HttpDelete("{id}")] // /reservations/:id 
        public ActionResult deleteReservation(int id) //send back a untyped ActionResult since I will never be sending a reservation back
        {
            Reservation existingReservation = reservationDao.Get(id);
            if (existingReservation == null) //if the reservation doesn't exist 
            {
                return NotFound(); //404
            }

            bool result = reservationDao.Delete(id);

            if (result) //if true (thing was deleted)
            {
                return NoContent(); //return 204 No Content 
            }
            else
            {
                return StatusCode(500);
            }


        }
    }
}
