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

        public HotelApiService(string apiUrl) //apiURL is where the API we want to interact with "lives" (http://localhost:3000)
        {
            if (client == null)
            {
                client = new RestClient(apiUrl); //build a client to interact with the API 
            }
        }

        public List<Hotel> GetHotels() //this should be at localhost:3000/hotels 
        {
            //build a request 
            RestRequest request = new RestRequest("hotels"); //make a request to /hotels

            //send the request to the API
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request); 
            //IRestResponse<T> is a container for the data coming back from the API
            //use the client (RestClient), make a GET request for a specific type of data, and use the request object that we built 

            if(!response.IsSuccessful) //check to see if my response was not a success so I can handle that situation
            {
                throw new HttpRequestException("Something when wrong communicating with the server!  OH NOES");
            }

            return response.Data; //the data is wrapped up in the response object 

        }

        public List<Review> GetReviews() //http://localhost:3000/reviews
        {
            //build a request 
            RestRequest request = new RestRequest("reviews"); //make a request to /reviews

            //send the request to the API
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            //IRestResponse<T> is a container for the data coming back from the API
            //use the client (RestClient), make a GET request for a specific type of data, and use the request object that we built 

            if (!response.IsSuccessful) //check to see if my response was not a success so I can handle that situation
            {
                throw new HttpRequestException("Something when wrong communicating with the server!  OH NOES");
            }

            return response.Data; //the data is wrapped up in the response object 
        }

        public Hotel GetHotel(int hotelId) // http://localhost:3000/hotels/1 where 1 is the hotel id 
        {
            RestRequest request = new RestRequest($"hotels/{hotelId}"); //add the id on to the end 
            IRestResponse<Hotel> response = client.Get<Hotel>(request);
 

            if (!response.IsSuccessful) 
            {
                throw new HttpRequestException("Something when wrong communicating with the server!  OH NOES");
            }

            return response.Data;
        }

        public List<Review> GetHotelReviews(int hotelId) // http://localhost:3000/reviews?hotelId=1 where 1 is the hotel id 
        {
            RestRequest request = new RestRequest($"reviews?hotelId={hotelId}"); //add the query parameter (?) + id on to the end 
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);


            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something when wrong communicating with the server!  OH NOES");
            }

            return response.Data;
        }

        public List<Hotel> GetHotelsWithRating(int starRating) // http://localhost:3000/hotels?stars=4
        {
            RestRequest request = new RestRequest($"hotels?stars={starRating}"); //add the query parameter
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);


            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something when wrong communicating with the server!  OH NOES");
            }

            return response.Data;
        }

        public City GetPublicAPIQuery()
        {
            RestRequest request = new RestRequest("https://api.teleport.org/api/cities/geonameid:5128581/"); //THIS IS ON THE ACTUAL INTERNET 
            IRestResponse<City> response = client.Get<City>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Something when wrong communicating with the server!  OH NOES");
            }
            return response.Data;
        }
    }
}
