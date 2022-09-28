using System;
using System.Collections.Generic;

namespace InheritanceLecture.Auctioneering
{
    /// <summary>
    /// This class represents a general auction.
    /// </summary>
    public class Auction
    {
        /// <summary>
        /// This is an encapsulated field that holds all placed bids.
        /// </summary>
        private List<Bid> allBids = new List<Bid>();

        /// <summary>
        /// Represents the current high bid.
        /// </summary>
        public Bid CurrentHighBid { get; private set; } = new Bid("", 0);

        /// <summary>
        /// All placed bids returned as an array.
        /// </summary>
        public Bid[] AllBids
        {
            get { return allBids.ToArray(); }
        }

        /// <summary>
        /// Indicates if the auction has ended yet.
        /// </summary>
        public bool HasEnded { get; private set; }

        /// <summary>
        /// Places a Bid on the Auction
        /// </summary>
        /// <param name="offeredBid">The bid to place.</param>
        /// <returns>True if the new bid is the current winning bid</returns>
        public virtual bool PlaceBid(Bid offeredBid) // virtual they can do their own thing
        {
            // Only accept bids if the auction has not ended.
            bool newHighBidPlaced = false;
            // Print out the bid details.
            Console.WriteLine(offeredBid.Bidder + " bid " + offeredBid.BidAmount.ToString("C"));
            //!HasEnded (not ended)
            if (HasEnded == false)
            {         // Record it as a bid by adding it to allBids
            allBids.Add(offeredBid);
            // Check to see IF the offered bid is higher than the current bid amount
            if (offeredBid.BidAmount > CurrentHighBid.BidAmount)
            { // if yes, set offered bid as the current high bid
                CurrentHighBid = offeredBid;
                newHighBidPlaced = true;
            }
        }
            else
            {
                Console.WriteLine("Bid not accepted - Auction has ended.");
            }

            // Output the current high bid
            Console.WriteLine($"Current highest bid {CurrentHighBid.BidAmount.ToString("C")} by {CurrentHighBid.Bidder}");
            // Return if this is the new highest bid
            return newHighBidPlaced;
        }
      //  public void EndAuction() this is the method signature
      
       
        //TODO- Stop acceping bids once auction is ended. 
        public void EndAuction()
        {
            //End the auction
            HasEnded = true;

            //Announce the winner
            Console.WriteLine($"Auction has finished, { CurrentHighBid.Bidder} won with a bid of {CurrentHighBid.BidAmount.ToString("C")}.");
        }
        // Method signature: parameters-ingredients to the recipe/ Return type: ex: void / Name: ex EndAuction / Access Modifier: ex public
    }
}
