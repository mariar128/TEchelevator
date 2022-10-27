using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao = null)
        {
            if (auctionDao == null)
            {
                dao = new AuctionMemoryDao();
            }
            else
            {
                dao = auctionDao;
            }

        }
        [HttpGet("{id}")]
        public ActionResult<Auction> GetAllAuctions(int id)
        {
            Auction auction = dao.Get(id);

            return auction;

        }

        [HttpGet()]

        public List<Auction> ListAuctions(string title_like = "", double currentBid_lte = 0.00)
        {
            //return dao.List();
            if (dao.SearchByTitle(title_like) != null && (currentBid_lte > 0.00))
            {
                return dao.SearchByTitleAndPrice(title_like, currentBid_lte);
            }
               else if (dao.SearchByTitle(title_like) != null && currentBid_lte == 0.00)
                {
                    return dao.SearchByTitle(title_like);
                }
              else if(dao.SearchByTitle(title_like) == null && currentBid_lte > 0.00)
            {
                return dao.SearchByPrice(currentBid_lte);
            }
                else
            {
                return dao.List();
            }
               
         
        }

        [HttpPost()]
        public ActionResult<Auction> AddAllAuctions(Auction newAuction)
        {
            Auction addedAuction = dao.Create(newAuction);
            if (newAuction != null)
            {
                return Created($"/auction/{addedAuction.Id}", addedAuction);
            }
            else
            {
                return newAuction;
            }
        }
        //[HttpGet("/auctions?title_like={searchTerm}")]
        //public List<Auction> SearchByTitle(string title_like = "")
        //{
        //    List<Auction> searchTerm = new List<Auction>();

        //    if (title_like != null)
        //    {
        //        return SearchByTitle();
        //    }
        //    else
        //    {
        //        return dao.List();
        //    }    
        //}
    }
}



                
                

                
      