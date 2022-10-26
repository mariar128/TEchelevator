using HotelReservations.DAO;
using HotelReservations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelReservations.Controllers
{
    [Route("reservations")] // localhost:????/reservations
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

        //get all the reservations
        [HttpGet()] //GET requests to /reservations
        public List<Reservation> GetAllReservations()
        {
            return reservationDao.List(); //get all the reservations from the DAO and return 'em 
        }


        //get reservation by id 
        [HttpGet("{id}")] // GET requests to /reservations/:id - {} are a placeholder for a variable
        public ActionResult<Reservation> GetReservationById(int id) //parameter name should match the name in route
        {
            Reservation reservation = reservationDao.Get(id); //go get the reservation from the DAO

            if (reservation != null)
            {
                return reservation;
            }
            else
            {
                return NotFound(); //return 404 
            }
        }

        //get reservations by hotel id - Tori's opinion is that it should go in the reservations controller
        //even though the expected route is /hotels/:id/reservations
        [HttpGet("/hotels/{hotelId}/reservations")] // starting with / yanks control of the route away from the route attribute and says "nah this is the path now"
        public ActionResult<List<Reservation>> ListReservationsByHotel(int hotelId) //matchy matchy naming
        {
            Hotel hotel = hotelDao.Get(hotelId); //something is wrong if the hotel doesn't exist
            if (hotel == null)
            {
                return NotFound();
            }
            return reservationDao.FindByHotel(hotelId); //but I'm okay with an empty list returning if no one has a reservation
        }


        //add reservation
        [HttpPost()] //POST requests to /reservations
        public ActionResult<Reservation> AddReservation(Reservation newReservation) //if expecting a data object from the request, it goes in the params
        {
            Reservation addedReservation = reservationDao.Create(newReservation); //try to add the new reservation to wherever our data comes from
            if (addedReservation != null)
            {
                //return the reservation + the 201 Created status  
                //Crated(URL of the new thing, the new thing)
                return Created($"/reservations/{addedReservation.Id}", addedReservation);
            }
            else
            {
                return Problem("Can't create this reservation");
            }
        }


        //update reservation
        [HttpPut("{id}")] // /reservations/:id 
        public ActionResult<Reservation> UpdateReservation(int id, Reservation reservation)
        {
            Reservation existingReservation = reservationDao.Get(id);
            if(existingReservation == null) //if the reservation doesn't exist 
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

            if(result) //if true (thing was deleted)
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
