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
        // get all reservations
        [HttpGet()] // get requests to reservations
        public List<Reservation> GetAllReservations()
        {
            return reservationDao.List(); // get all the reservations from the DAO and return them
        }
        //get reservation by id
        [HttpGet("{id}")] // GET requests to /reservations/:id {} are a placeholder for a varaible
        public ActionResult<Reservation> GetReservationById(int id)   // parameter name should match token in route
        {
            Reservation reservation = reservationDao.Get(id); // go get the reservation from the DAO
            if(reservation != null)
            {
                return reservation;
            }
            else
            {
                return NotFound(); // return 404
            }
        }

        // get reservations by hotel id -- it should go in the reservations controller even tho the expected route is /hotels/:id/reservations
        [HttpGet("/hotels/{hotelid}/reservations")]
        public ActionResult<List<Reservation>> ListReservationsByHotel(int hotelId) // matchy matchy naming
        {
            Hotel hotel = hotelDao.Get(hotelId); // something is wrong if the hotel doesn't exist
            if(hotel == null)
            {
                return NotFound();
            }
            return reservationDao.FindByHotel(hotelId);
        }
        // add reservation
        [HttpPost()] //POST requests to /reservations
        public ActionResult<Reservation> AddReservation(Reservation newReservation)
        {
            Reservation addedReservation = reservationDao.Create(newReservation);
            if(AddReservation != null)
            {
                //return the reservation + the 201 Created status
                //Crated(URL of the new thing, the new thing)
                return Created($"/reservations/{addedReservation.Id}", addedReservation);
            }
            else
            {
                return Problem("Can't create this reservation");
            }
        }// if expecting a data object from the request, it goes in the 
        //update reservation
        [HttpPut("{id}")]
        public ActionResult<Reservation> UpdateReservation(int id, Reservation reservation)
        {
            Reservation existingReservation = reservationDao.Get(id);
            if(existingReservation == null)
            {
                return NotFound(); //404
            }
            Reservation updatedReservation = reservationDao.Update(existingReservation.Id, reservation);

            return updatedReservation;
        }
        //delete reservation
        [HttpDelete("{id}")]
        public ActionResult<Reservation> deleteReservation(int id)
        {
            Reservation existingReservation = reservationDao.Get(id);
            if (existingReservation == null)
            {
                return NotFound(); //404
            }
            bool result = reservationDao.Delete(id);
            if(result) // if true (thing was deleted)
            {
                return NoContent(); // return 204 No content 
            }
            else
            {

            }
            Reservation updatedReservation = reservationDao.Update(existingReservation.Id, reservation);

            return updatedReservation;
        }
}
