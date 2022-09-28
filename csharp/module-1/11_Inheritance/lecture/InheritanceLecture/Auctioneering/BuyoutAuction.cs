using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    public class BuyoutAuction : Auction // parent class - class being inherited from.
    {
        public BuyoutAuction(int buyoutPrice) : base()
        {
            _buyoutPrice = buyoutPrice;
        }



        // buyout price- backing field


        



        //Readonly get;

        private int _buyoutPrice;
        public int BuyoutPrice
        {
            get
            {
                return _buyoutPrice;
            }
        }
        public override bool PlaceBid(Bid offeredBid)
        {
            // if buyout place is not met place bid as normal. (Auction) (Base = go to my parent and do something w it)
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
