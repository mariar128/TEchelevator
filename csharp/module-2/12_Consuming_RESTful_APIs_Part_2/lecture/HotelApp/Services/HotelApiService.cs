using HotelReservationsClient.Models;
using HotelReservationsClient.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HotelReservationsClient.Services
{
    public class HotelApiService
    {
        protected static RestClient client = null;

        public HotelApiService(string apiUrl)
        {
            if (client == null)
            {
                client = new RestClient(apiUrl);
            }
        }

        public List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest("hotels");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

            CheckForError(response, "Get hotels");
            return response.Data;
        }

        public List<Reservation> GetReservations(int hotelId = 0) //default value for the parameter
        {
            string url;
            if (hotelId != 0)
            {
                url = $"hotels/{hotelId}/reservations"; // if a hotel id is passed in, get the reservations just for that hotel
            }
            else
            { 
                url = "reservations"; // if not, get all the reservations for all the hotels
            }

            RestRequest request = new RestRequest(url);
            IRestResponse<List<Reservation>> response = client.Get<List<Reservation>>(request);

            CheckForError(response, $"Get reservations for hotel {hotelId}");
            return response.Data;
        }

        public Reservation GetReservation(int reservationId)
        {
            RestRequest request = new RestRequest($"reservations/{reservationId}");
            IRestResponse<Reservation> response = client.Get<Reservation>(request);

            CheckForError(response, $"Get reservation {reservationId}");
            return response.Data;
        }

        public Reservation AddReservation(Reservation newReservation)
        {
            // build a request and send it to http://localhosy:3000/reservations
            // the endpoint doesn't change, but the HTTP method does depending on actions we want to take
            RestRequest request = new RestRequest("reservations");
            request.AddJsonBody(newReservation);
            IRestResponse<Reservation> response = client.Post<Reservation>(request); // send the request
            // check for success
            CheckForError(response, $"Add reservation for {newReservation.HotelId}");
            // we know that when we POST to that endpoint, we get a reservation object back with a reservation id
            return response.Data;
        }
        
        public Reservation UpdateReservation(Reservation reservationToUpdate)
        {
            // http://localhost:3000/reservations/:id
            RestRequest request = new RestRequest($"reservations/{reservationToUpdate.Id}");
            request.AddJsonBody(reservationToUpdate); // add the object that is being updated
                IRestResponse<Reservation> response = client.Put<Reservation>(request);
            CheckForError(response, $"Add reservation for {reservationToUpdate.HotelId}");
            return response.Data;
        }

        public bool DeleteReservation(int reservationId)
        {
            // http://localhost:3000/reservations/:id
            RestRequest request = new RestRequest($"reservations/{reservationId}");
            IRestResponse response = client.Delete(request);
            CheckForError(response, $"Delete reservation {reservationId}");
            return true;
        }

        /// <summary>
        /// Checks RestSharp response for errors. If error, writes a log message and throws an exception 
        /// if the call was not successful. If no error, just returns to caller.
        /// </summary>
        /// <param name="response">Response returned from a RestSharp method call.</param>
        /// <param name="action">Description of the action the application was taking. Written to the log file for context.</param>
        private void CheckForError(IRestResponse response, string action)
        {
            if (!response.IsSuccessful)
            {
                // TODO: Write a log message for future reference

                throw new HttpRequestException($"There was an error in the call to the server");
            }

        }
    }
}
