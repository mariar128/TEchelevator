using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    public class BuyoutAuction : Auction
    {
        public BuyoutAuction(int buyoutPrice) : base()
        {
            this._buyoutPrice = buyoutPrice;
        }

        //Buyout price - backing field
        private int _buyoutPrice;


        //Readonly get;
        public int BuyoutPrice 
        { 
            get
            {
                return _buyoutPrice;
            }
        }

        public override bool PlaceBid(Bid offeredBid)
        {
            //If buyout price is not met place bid as normal. (Auction)
            bool newHighBid = base.PlaceBid(offeredBid);

            if(newHighBid && offeredBid.BidAmount >= this.BuyoutPrice)
            {
                Console.WriteLine("Buyout met by " + offeredBid.Bidder);
                base.EndAuction();
            }

            return newHighBid;
        }

    }
}
