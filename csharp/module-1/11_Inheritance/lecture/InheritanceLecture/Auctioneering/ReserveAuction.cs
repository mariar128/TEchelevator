using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    public class ReserveAuction : Auction
    {
        public ReserveAuction(int reservePrice) : base()
        {
            _reservePrice = reservePrice;
        }
        private int _reservePrice;

        public int ReservePrice
        {
            get
            {
                return _reservePrice;
            }
        }

        public override bool PlaceBid(Bid offeredBid)
        {
            // check to make sure offeredBid is greater than reservePrice.
            if (offeredBid.BidAmount >= this.ReservePrice)
            {
                Console.WriteLine("Reserve amount has been met.");
                return base.PlaceBid(offeredBid);
            }
            else
            {
                Console.WriteLine($"Reserve price not met. Reserve price is {this.ReservePrice}");
            }

            return false;
        }


    }

}
