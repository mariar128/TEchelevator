using RestSharp;
using System.Collections.Generic;
using AuctionApp.Models;

namespace AuctionApp.Services
{
    public class AuctionApiService
    {
        public IRestClient client;

        public AuctionApiService(string apiUrl)
        {
            client = new RestClient(apiUrl);
        }

        public List<Auction> GetAllAuctions()
        {
            // build a request
            RestRequest request = new RestRequest("auctions"); // make a request to hotels
            // send the request to the API
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            // IRestResponse<T> is a container for the data coming back from the API
            //use the client (RestClient), make a GET request for a speciifc type of data, and use the request object that we built
            if (!response.IsSuccessful) // check to see if my response was not a success so I can handle that situation
            {
                throw new System.NotImplementedException("Something went wrong communicating with the Server! ");
            }
            return response.Data; // the data is wrapped up in the response object

        }

        public Auction GetDetailsForAuction(int auctionId) // http://localhost:3000/auctions/{id}
        {
            RestRequest request = new RestRequest($"auctions/{auctionId}"); // make a request to hotels
            // send the request to the API
            IRestResponse<Auction> response = client.Get<Auction>(request);

            if (!response.IsSuccessful) // check to see if my response was not a success so I can handle that situation
            {
                throw new System.NotImplementedException("Something went wrong communicating with the Server! ");
            }
            return response.Data; // the data is wrapped up in the response object
           
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTerm)
        {
            RestRequest request = new RestRequest($"auctions?title_like={searchTerm}"); // make a request to hotels
                                                                                 // send the request to the API
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);

            if (!response.IsSuccessful) // check to see if my response was not a success so I can handle that situation
            {
                throw new System.NotImplementedException("Something went wrong communicating with the Server! ");
            }
            return response.Data; // the

        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            RestRequest request = new RestRequest($"auctions?currentBid_lte={searchPrice}"); // make a request to hotels
                                                                                 // send the request to the API
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);

            if (!response.IsSuccessful) // check to see if my response was not a success so I can handle that situation
            {
                throw new System.NotImplementedException("Something went wrong communicating with the Server! ");
            }
            return response.Data; // the
        }
    }
    }


