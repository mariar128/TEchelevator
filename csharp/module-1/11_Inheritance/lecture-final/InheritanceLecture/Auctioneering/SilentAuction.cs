using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    public class SilentAuction : BuyoutAuction 
    {
        //BuyoutAuction needs a price. 
        //SilentAuction constructor must provide date to the base(BuyoutAuction) constructor. 
        public SilentAuction(int buyoutPrice) : base(buyoutPrice)
        {

        }

    }
}
