namespace Exercises.Classes
{
    public class Airplane
    {


        public int TotalFirstClassSeats { get; private set; }
        public string PlaneNumber { get; private set; }
        public int BookedFirstClassSeats { get; private set; }
        public int AvailableFirstClassSeats
        {
            get
            {
                return TotalFirstClassSeats - BookedFirstClassSeats;
            }
        }
        public int TotalCoachSeats { get; private set; }
        public int BookedCoachSeats { get; private set; }
        public int AvailableCoachSeats
        {
            get
            {
                return TotalCoachSeats - BookedCoachSeats;

            }
        }
        public Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSeats)
        {

            this.PlaneNumber = planeNumber;
            this.TotalFirstClassSeats = totalFirstClassSeats;
            this.TotalCoachSeats = totalCoachSeats;
        }

        public bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)
        {

            if (forFirstClass == true)
            {
                if (AvailableFirstClassSeats >= totalNumberOfSeats)
                {
                    BookedFirstClassSeats += totalNumberOfSeats;
                    return true;
                }
                return false;
            }

            if (forFirstClass == false)
            {
                if (AvailableCoachSeats >= totalNumberOfSeats)
                {
                    BookedCoachSeats += totalNumberOfSeats;
                    return true;
                }
                return false;
            }
            return false;



    }

    }
}
    









