 using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;
using Microsoft.AspNetCore.Authorization;

namespace AuctionApp.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao auctionDao;

        public AuctionsController(IAuctionDao auctionDao)
        {
            this.auctionDao = auctionDao;
        }

        [AllowAnonymous]
        [HttpGet]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                return auctionDao.SearchByTitle(title_like);
            }
            if (currentBid_lte > 0)
            {
                return auctionDao.SearchByPrice(currentBid_lte);
            }

            return auctionDao.List();
        }

        [HttpGet("{id}")]

        [Authorize]
        public ActionResult<Auction> Get(int id)
        {
            Auction auction = auctionDao.Get(id);
            if (auction != null)
            {
                return Ok(auction);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize (Roles = "admin, creator")]
        [HttpPost]
        [Authorize]
        public ActionResult<Auction> Create(Auction auction)
        {
            Auction returnAuction = auctionDao.Create(auction);
            return Created($"/auctions/{returnAuction.Id}", returnAuction);
        }

        [Authorize (Roles = "admin, creator")]
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Auction> Update(int id, Auction auction)
        {
            Auction existingAuction = auctionDao.Get(id);
            if (existingAuction == null)
            {
                return NotFound();
            }

            Auction result = auctionDao.Update(id, auction);
            return Ok(result);
        }

        [Authorize (Roles = "admin")]
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            Auction auction = auctionDao.Get(id);
            if (auction == null)
            {
                return NotFound();
            }

            bool result = auctionDao.Delete(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("whoami")]
        [Authorize]
        public ActionResult WhoAmI()
        {
            return Ok(User.Identity.Name);
        }
    }
}
