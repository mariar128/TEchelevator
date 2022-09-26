using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    public class ReserveAuction : Auction
    {
        public ReserveAuction(int reservePrice) :base()
        {
            this._reservePrice = reservePrice;
        }

        private int _reservePrice;

        public int ReservePrice
        {
            get
            {
                return this._reservePrice;
            }
        }

        public override bool PlaceBid(Bid offeredBid)
        {
            //check to make sure offeredBid is greater than reservePrice.
            if (offeredBid.BidAmount >= this.ReservePrice)
            {
                Console.WriteLine("Reserve ammount has been met.");
                return base.PlaceBid(offeredBid);
            }
            else
            {
                Console.WriteLine($"Reserve price not meet. Reserve price is {this.ReservePrice}.");
            }

            return false;

        }
    }
}
