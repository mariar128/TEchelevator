using HotelApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HotelApp.Services
{
    public class HotelApiService
    {
        protected static RestClient client = null;

        public HotelApiService(string apiUrl) // apiURL is where the API we want to interact with "lives"
        {
            if (client == null)
            {
                client = new RestClient(apiUrl); //build a client to interact with the API (im a nerd)
            }
        }

        public List<Hotel> GetHotels() // this should be at localhost:3000/hotels
        {
            // build a request
            RestRequest request = new RestRequest("hotels"); // make a request to hotels
            // send the request to the API
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            // IRestResponse<T> is a container for the data coming back from the API
            //use the client (RestClient), make a GET request for a speciifc type of data, and use the request object that we built
            if(!response.IsSuccessful) // check to see if my response was not a success so I can handle that situation
            {
                throw new HttpRequestException("Something went wrong communicating with the Server! ");
            }
            return response.Data; // the data is wrapped up in the response object
                                           
        }

        public List<Review> GetReviews() //http://localhost:3000/reviews 
        {
            RestRequest request = new RestRequest("reviews"); // make a request to hotels
            // send the request to the API
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);

            if (!response.IsSuccessful) // check to see if my response was not a success so I can handle that situation
            {
                throw new HttpRequestException("Something went wrong communicating with the Server! ");
            }
            return response.Data; // the data is wrapped up in the response object
        }
               public Hotel GetHotel(int hotelId) // http://localhost:3000/hotels/1
        {
            RestRequest request = new RestRequest($"hotels.{hotelId}"); // make a request to hotels
            // send the request to the API
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

            if (!response.IsSuccessful) // check to see if my response was not a success so I can handle that situation
            {
                throw new HttpRequestException("Something went wrong communicating with the Server! ");
            }
            return response.Data; // the data is wrapped up in the response object
        }

            
        

        public List<Review> GetHotelReviews(int hotelId)
        {

        RestRequest request = new RestRequest($"reviews?hotelId={hotelId}"); // make a request to hotels
                                                                    // send the request to the API
        IRestResponse<List<Review>> response = client.Get<List<Review>>(request);

        if (!response.IsSuccessful) // check to see if my response was not a success so I can handle that situation
        {
            throw new NotImplementedException("Something went wrong communicating with the Server! ");
        }
        return response.Data; // the
        
        }

        public List<Hotel> GetHotelsWithRating(int starRating)
        {
        RestRequest request = new RestRequest($"hotels?stars={starRating}"); // make a request to hotels
                                                                             // send the request to the API
        IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

        if (!response.IsSuccessful) // check to see if my response was not a success so I can handle that situation
        {
            throw new NotImplementedException("Something went wrong communicating with the Server! ");
        }
        return response.Data; // the
    }

        public City GetPublicAPIQuery()
        {
            throw new NotImplementedException();
        }
    }
}
